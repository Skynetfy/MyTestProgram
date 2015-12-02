using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    public class EmployeeService : IEmployeeService
    {
        private static IList<Employee> employees = new List<Employee>
        {
            new Employee{ Id = 001, Name="张三", Department="开发部", Grade = "G7"},    
            new Employee{ Id = 002, Name="李四", Department="人事部", Grade = "G6"}
        };

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

        public Employee Get(string id)
        {
            var m = employees.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
            if (m == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            return m;
        }

        public void Create(Employee e)
        {
            employees.Add(e);
        }

        public void Update(Employee e)
        {
            this.Delete(e.Id.ToString());

            employees.Add(e);
        }

        public void Delete(string id)
        {
            Employee e = this.Get(id);

            if (e != null)
                employees.Remove(e);
        }
    }
}
