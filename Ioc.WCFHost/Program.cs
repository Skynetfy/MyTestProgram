using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Ioc.WCFMSMQ;
using WsHttpBinding;

namespace Ioc.WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = args.GetType();
            using (ServiceHost host = new ServiceHost(typeof(HomeService), new Uri("http://127.0.0.1:19200")))
            {
                try
                {

                    host.AddServiceEndpoint(typeof(IHomeService), new BasicHttpBinding(), "HomeService");

                    host.AddServiceEndpoint(typeof(IHomeService), new NetTcpBinding() { PortSharingEnabled = true }, "net.tcp://127.0.0.1:1921/HomeServieTcp");

                  

                    host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                    // host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });

                    host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(),
                        "mex");

                    host.Open();

                    Console.WriteLine("服务开启！");

                    //Console.Read();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            using (var host1 = new ServiceHost(typeof(People), new Uri("net.tcp://127.0.0.1:1921")))
            {
                host1.AddServiceEndpoint(typeof(IFly), new NetTcpBinding() { PortSharingEnabled = true }, "PeopleTcp");
                host1.Open();
            }
        }
    }
}
