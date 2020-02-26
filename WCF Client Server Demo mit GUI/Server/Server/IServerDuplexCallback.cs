using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Server
{
    /*
     * Im IServerDuplexCallback definieren wir nur eine einzige Methode, die der Client implementieren muss.
     * Diese ist hier asynchron ausgeführt und teilt sich somit in eine “Begin…” und eine “End…” – Methode. 
     * Der Grund warum hier eine asynchrone anstelle einer “normalen” Methode verwendet wird ist, 
     * dass dadurch der Server selbst die Callback-Methoden der Clients ansynchron ausführt.
     * Das ist wichtig, denn wenn mehrere Clients verbunden sind, und der Server eine Nachricht an alle
     * innerhalb einer Schleife “pusht”, dann würde ein einzelner Client mit einer fehlerhaften Verbindung 
     * den Aufruf an die nachfolgenden Clients verzögern (bis zum Timeout, und der kann lang eingestellt sein!).
     */
    interface IServerDuplexCallback
    {
        [OperationContract(IsOneWay = true, AsyncPattern = true)]
        IAsyncResult BeginOnMessageReceived(string message, AsyncCallback acb, object state);
        void EndOnMessageReceived(IAsyncResult iar);
    }
}
