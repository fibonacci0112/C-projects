using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Server
{
    /*
     * Durch die Verwendung dieses InstanceContextMode erzwingen wir, dass das Service als Singleton ausgeführt, 
     * also nur ein einziges mal instantiiert wird. 
     * Das ist wichtig, denn in einem privaten Feld speichern wir die Liste der verbundenen Clients mit deren 
     * SessionId ab, die wir für die Methode PublishMessage() brauchen um die Callbacks der verbundenen Clients 
     * aufzurufen. 
     * Der Rest des Codes sollte selbsterklärend sein, bzw. aus den Kommentaren deutlich werden. 
     * Einzig dem lock(syncRoot) kommt noch eine besondere Bedeutung zu.
     * Wir verwenden dieses um sicherzustellen, dass mehrere Threads nicht gleichzeitig das Dictionary der 
     * Clients verwenden. Zwar sind alle Collections des .NET – Frameworks an sich schon Thread sicher, 
     * jedoch könnte es ohne das explizite locken zu Problemen kommen, wenn ein Thread gerade die 
     * foreach-Schleife beim Pushen durchläuft und gleichzeitig dem Dictionary ein Eintrag hinzugefügt oder 
     * entfernt wird, indem sich Clients an- oder abmelden.
     */
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Server : IServerDuplex
    {
        // returns the singleton-instance
        public static Server CurrentInstance { get; private set; }

        // holds the channels to all currently connected callbacks (=clients)
        private volatile IDictionary<string, IServerDuplexCallback> connectedClients;

        // lock-object to synchronize between multiple concurrent threads
        private object syncRoot;


        public Server()
        {
            if (CurrentInstance != null)
            {
                throw new Exception("This service-class is intended to be instatiated only once!");
            }
            CurrentInstance = this;

            syncRoot = new object();
            connectedClients = new Dictionary<string, IServerDuplexCallback>();
        }


        public void Anmelden(Guid guid)
        {
            // get the callback-channel to the client that called this method
            var callbackChannel = OperationContext.Current.GetCallbackChannel<IServerDuplexCallback>();
            string sessionId = OperationContext.Current.Channel.SessionId;

            // store it for later use (to push messages)
            lock (syncRoot)
            {
                // make sure, that we don't add the same session twice (e.g. the client tries to subscribe multiple times)
                if (!connectedClients.ContainsKey(sessionId))
                {
                    connectedClients.Add(sessionId, callbackChannel);

                    // register for error-events of the current channel
                    OperationContext.Current.Channel.Closing += new EventHandler(Channel_Closing);
                    OperationContext.Current.Channel.Faulted += new EventHandler(Channel_Faulted);
                    Console.WriteLine("Anmeldung: {0}", guid);
                    PublishMessage("Anmeldung: " + guid);
                }
                else
                {
                    Console.WriteLine("War bereits angemeldet: {0}", guid);
                    PublishMessage("War bereits angemeldet: " + guid);
                }
            }
        }


        public void Abmelden(Guid guid)
        {
            Console.WriteLine("Abmeldung: {0}", guid);
            PublishMessage("Abmeldung: " + guid);
            DisconnectClient(OperationContext.Current.Channel.SessionId);
        }


        private void Channel_Faulted(object sender, EventArgs e)
        {
            var channel = sender as IContextChannel;
            if (channel != null)
            {
                DisconnectClient(channel.SessionId);
            }
        }


        private void Channel_Closing(object sender, EventArgs e)
        {
            var channel = sender as IContextChannel;
            if (channel != null)
            {
                DisconnectClient(channel.SessionId);
            }
        }


        private void DisconnectClient(string sessionId)
        {
            // remove the session
            lock (syncRoot)
            {
                if (connectedClients.ContainsKey(sessionId))
                {
                    connectedClients.Remove(sessionId);
                }
            }
        }


        public void PublishMessage(string message)
        {
            lock (syncRoot)
            {
                // iterate through all connected clients and push message to each of them
                foreach (var callbackChannel in connectedClients.Values)
                {
                    // call the callback-method asynchronously, so that a leaking connection to one of the clients does not affect this loop
                    var asyncResult = callbackChannel.BeginOnMessageReceived(message, new AsyncCallback(OnPushMessageComplete), callbackChannel);
                    if (asyncResult.CompletedSynchronously)
                    {
                        CompletePushMessage(asyncResult);
                    }
                }
            }
        }


        void OnPushMessageComplete(IAsyncResult asyncResult)
        {
            CompletePushMessage(asyncResult);
        }


        void CompletePushMessage(IAsyncResult asyncResult)
        {
            var callbackChannel = (IServerDuplexCallback)asyncResult.AsyncState;
            try
            {
                callbackChannel.EndOnMessageReceived(asyncResult);
            }
            catch
            {
            }
        }
    }
}
