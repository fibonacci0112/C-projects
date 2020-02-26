using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Server
{
    [ServiceContract(CallbackContract = typeof(IServerDuplexCallback))]
    public interface IServerDuplex
    {
        [OperationContract(IsOneWay = true)]
        void Anmelden(Guid guid);

        [OperationContract(IsOneWay = true)]
        void Abmelden(Guid guid);
    }
}