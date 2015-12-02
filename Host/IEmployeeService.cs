using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace Host
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [WebGet(UriTemplate = "all")]
        IEnumerable<Employee> GetAll();

        [WebGet(UriTemplate = "{id}")]
        Employee Get(string  id);

        [WebInvoke(UriTemplate = "/",Method = "POST")]
        void Create(Employee employee);

        [WebInvoke(UriTemplate = "/", Method = "PUT")]
        void Update(Employee employee);

        [WebInvoke(UriTemplate = "{id}", Method = "Delete")]
        void Delete(string id);
    }
}
