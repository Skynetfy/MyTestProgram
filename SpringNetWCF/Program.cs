using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpringNetWCF.ServiceReference1;
using SpringNetWCF.ServiceReference2;

namespace SpringNetWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            SpringNetWCF.ServiceReference2.Service1Client client = new Service1Client();
            var c = client.GetData(123);
        }
    }
}
