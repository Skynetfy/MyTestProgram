using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Spring.Net.App1
{
    public class PersonDao
    {

        public class Person
        {
            public Person()
            {
                Console.WriteLine("Person被实例");
            }

            ~Person()
            {
                Console.WriteLine("Person被销毁");
            }

            public override string ToString()
            {
                return "我是全套类Person";
            }
        }
        public override string ToString()
        {
            return "我是PersonDao";
        }

    }
}
