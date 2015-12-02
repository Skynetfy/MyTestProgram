using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;

namespace Ioc.Spring.Net.App1
{
    class Program
    {
        static string _objectXmlFile = "assembly://Ioc.Spring.Net.App1/Ioc.Spring.Net.App1/Objects1.xml";
        static void Main(string[] args)
        {
            //IApplicationContext ctx = ContextRegistry.GetContext();
            //Console.WriteLine(ctx.GetObject("PersonDao").ToString());
            //CreateByConstructor();
            //CreateNested();
            //CreateByStaticFactory();
            //CreateByInstanceFactory();
            //CreateGenericClass();
            //ApplyIocMethod();
            //Test1();
            Test3();
        }

        static void Test3()
        {
            string[] xmlFiles = new string[] 
            {
                _objectXmlFile
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            Door door = (Door)factory.GetObject("door");
            door.OnOpen("Opening!");
            Console.WriteLine();
        }
        static void Test2()
        {
            ObjectFactory factory = ObjectFactory.Instance(@"E:\work\Hangfire_service\HangfireService.Pro\Ioc.Spring.Net.App1\Objects1.xml");

            //string[] xmlFiles = new string[] 
            //{
            //    _objectXmlFile
            //};
            //IApplicationContext context = new XmlApplicationContext(xmlFiles);

            //IObjectFactory factory = (IObjectFactory)context;
            StudentDao dao = (StudentDao)factory.GetObject("studentDao");

            Console.WriteLine("姓名：" + dao.Entity.Name);
            Console.WriteLine("年龄：" + dao.Entity.Age);
            Console.WriteLine(dao);
        }

        /// <summary>
        /// 构造器创建
        /// </summary>
        static void CreateByConstructor()
        {
            string[] xmlFiles = new string[] 
            {
                _objectXmlFile
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            Console.WriteLine(factory.GetObject("personDao").ToString());
        }
        /// <summary>
        /// 嵌套类型创建
        /// </summary>
        static void CreateNested()
        {
            string[] xmlFiles = new string[] 
            {
                _objectXmlFile
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            Console.WriteLine(factory.GetObject("person").ToString());
            Console.WriteLine(factory.GetObject("person").ToString());
            Console.WriteLine(factory.GetObject("person").ToString());
            Console.WriteLine(factory.GetObject("person").ToString());
        }
        /// <summary>
        /// 静态工厂创建
        /// </summary>
        static void CreateByStaticFactory()
        {
            string[] xmlFiles = new string[] 
            {
                _objectXmlFile
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            Console.WriteLine(factory.GetObject("staticObjectsFactory").ToString());
        }
        /// <summary>
        /// 实例工厂创建
        /// </summary>
        static void CreateByInstanceFactory()
        {
            string[] xmlFiles = new string[] 
            {
               _objectXmlFile
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            Console.WriteLine(factory.GetObject("instancePersonDao").ToString());
        }
        /// <summary>
        /// 创建泛型
        /// </summary>
        static void CreateGenericClass()
        {
            string[] xmlFiles = new string[] 
            {
                _objectXmlFile
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;

            object obj = factory.GetObject("genericClass");

            Console.WriteLine(obj.ToString());
        }
        /// <summary>
        /// 依赖注入应用
        /// </summary>
        private static void ApplyIocMethod()
        {
            string[] xmlFiles = new string[] 
            {
                _objectXmlFile
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;

            Peaple obj = (Peaple)factory.GetObject("modernPerson");

            obj.Work();
            Console.ReadLine();
        }

        static void Test1()
        {
            string[] xmlFiles = new string[] 
            {
                _objectXmlFile
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            Friend friend = factory.GetObject("Friend") as Friend;

            Console.WriteLine("空值");
            string bestFriend = friend.BestFriends == null ? "我的朋友太多了" : "我只有一个好朋友";
            Console.WriteLine(bestFriend);
            Console.WriteLine();

            Console.WriteLine("IList");
            foreach (var item in friend.HappyYears)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("泛型Ilist<int>");
            foreach (int item in friend.Years)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("IDictionary");
            foreach (DictionaryEntry item in friend.HappyDic)
            {
                Console.WriteLine(item.Key + " 是 " + item.Value);
            }
            Console.WriteLine();

            Console.WriteLine("泛型IDictionary<string,object>");
            foreach (KeyValuePair<string, object> item in friend.HappyTimes)
            {
                Console.WriteLine(item.Key + " 是 " + item.Value);
            }

            Console.ReadLine();
        }

    }
}
