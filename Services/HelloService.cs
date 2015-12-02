using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Services
{
    public class HelloServices : IHelloServices
    {
        public string GetMessage(string message)
        {
            return message + "\t" + DateTime.Now;
        }
    }
}
