using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Spring.Net.App1
{
    public class InstanceObjectsFactory
    {
        public PersonDao CreateInstance()
        {
            return new PersonDao();
        }
    }
}
