using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;

namespace Ioc.Spring.Net.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            Console.WriteLine(ctx.GetObject("PersonDao").ToString());
           // AppRegistry();
            CreateByConstructor();
        }
        /// <summary>
        /// 构造器创建
        /// </summary>
        static void CreateByConstructor()
        {
            string[] xmlFiles = new string[] 
            {
                "assembly://Ioc.Spring.Net.App/Ioc.Spring.Net.App/SpringObjects.xml"
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            Console.WriteLine(factory.GetObject("personDao").ToString());
        }
        static void AppRegistry()
        {
            MyXmlFactory ctx = new MyXmlFactory(@"D:\Objects.xml");
            Console.WriteLine(ctx.GetObject("PersonDao").ToString());
        }
    }
}
