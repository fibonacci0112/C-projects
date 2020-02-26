using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Client_Demo
{
    public delegate void MessageReceivedEventHandler(string message);

    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public class CallbackHandler : IServerDuplexCallback
    {
        public event MessageReceivedEventHandler MessageReceived;

        public void OnMessageReceived(string message)
        {
            if (this.MessageReceived != null)
            {
                this.MessageReceived(message);
            }
        }
    }
}
