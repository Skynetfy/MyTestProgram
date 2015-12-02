using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SpringNetWCF
{
    [ServiceContract]
    interface IWcfContract
    {

        [OperationContract]
        string GetData(string value);
    }
}
