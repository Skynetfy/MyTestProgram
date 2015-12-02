using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServiceStack.Redis;
using Ioc.Core.Data;
using Ioc.WPFRedisClient.Redis;
using ServiceStack.Text;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;

namespace Ioc.WPFRedisClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // CreateByConstructor();

            var path1 = Environment.CurrentDirectory;
            var path2 = AppDomain.CurrentDomain.BaseDirectory;
        }
        /// <summary>
        /// 构造器创建
        /// </summary>
        static void CreateByConstructor()
        {
            string[] xmlFiles = new string[] 
            {
                "assembly://Ioc.WPFRedisClient/Ioc.WPFRedisClient/Objects.xml"
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            Console.WriteLine(factory.GetObject("personDao").ToString());
        }
        protected void Init1()
        {
            RedisClient redisClient = new RedisClient("127.0.0.1", 6379);
            var key_ = redisClient.Get<string>("key_");
            redisClient.Set("go", "狗");
            var user = new User
            {
                UserName = "张三",
                Password = "1234567",
                Email = "369552841@qq.com"
            };
            redisClient.Set<User>("UserModel", user);

            //redisClient
            redisClient.Custom("SET", "goto", 1);
            var c = redisClient.Custom(Commands.Get, "goto");
        }

        protected void Init2()
        {
            var c = new RedisTestManager();
            c.AddData();
        }
    }
}