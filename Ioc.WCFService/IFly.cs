using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Ioc.WCFService
{
    //定义服务契约
    [ServiceContract]
    public interface IFly
    {
        [OperationContract]
        string Fly(string name);
    }
}
