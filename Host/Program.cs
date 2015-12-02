using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Services;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Binding3();
        }

        static void Binding3()
        {
            using (WebServiceHost webHost = new WebServiceHost(typeof (EmployeeService)))
            {
                webHost.Open();
                Console.Read();
            }
        }

        static void Binding2()
        {
            using (ServiceHost host = new ServiceHost(typeof (CalculatorService)))
            {
                host.Opened += delegate { Console.WriteLine("TCP服务已启动！"); };
                host.Open();
                Console.Read();
            }
        }

        static void Binding1()
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(),
                    "http://127.0.0.1:9990/calculatorservice");

                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    var sBehavior = new ServiceMetadataBehavior();
                    sBehavior.HttpGetEnabled = true;
                    sBehavior.HttpGetUrl = new Uri("http://127.0.0.1:9990/calculatorservice/metadata");

                    host.Description.Behaviors.Add(sBehavior);
                }

                host.Opened += delegate
                {
                    Console.WriteLine("CalculaorService已经启动，按任意键终止服务！");
                };

                host.Open();
                Console.Read();
            }
        }
    }
}
