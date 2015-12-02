using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.WCFMSMQ
{
    [ServiceContract]
    public interface IOrder
    {
        [OperationContract(IsOneWay = true)]
        void Add(string order);
    }
}
