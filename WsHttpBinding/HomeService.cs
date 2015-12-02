using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WsHttpBinding
{
    public class HomeService:IHomeService
    {
         public int GetLength(string name)
         {
             return name.Length;
         }

        public Student Update(Student model)
        {
            return new Student() {Name = "张三", Age = 21};
        }
    }
}
