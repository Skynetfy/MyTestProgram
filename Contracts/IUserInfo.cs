using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace Contracts
{

    [ServiceContract]
    public interface IUserInfo
    {
        [OperationContract]
        string GetUserInfo();
    }
}
