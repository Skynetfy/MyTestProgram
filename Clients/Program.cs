using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;
using CacheLibrary;
using CacheLibrary.DataEntity;
using Contracts;
using Couchbase;
using Couchbase.Configuration;
using Enyim.Caching.Memcached;
using Services;

namespace Clients
{
    class Program
    {
        private static int maxThread = 500;
        private static List<TestTask> taskList;
        private static int sleepTime = 50;
        private static bool isWorking = false;
        private static DateTime startTime;
        private static int counter;

        static void Main(string[] args)
        {
            var cbCacheService = CouchbaseCacheFactory.GetCurrentCache();
            var Plist = new List<Person>()
            {
                new Person()
                {
                    Gid = new Guid(),
                    Name = "1",
                    Age = 12,
                    Sex = SexEnum.男
                },
                new Person()
                {
                    Gid = new Guid(),
                    Name = "2",
                    Age = 11,
                    Sex = SexEnum.女
                },
                new Person()
                {
                    Gid = new Guid(),
                    Name = "4",
                    Age = 41,
                    Sex = SexEnum.人妖
                },
            };
            cbCacheService.AddCache("key_1", Plist);

            var d = cbCacheService.GetAllCache<Person>("key_1");

            Console.WriteLine(cbCacheService.GetAllCache<Person>("key_1"));
            //配置服务器   
            CouchbaseClientConfiguration cbcc = new CouchbaseClientConfiguration();
            //设置各种超时时间   
            cbcc.SocketPool.ReceiveTimeout = new TimeSpan(0, 0, 2);
            cbcc.SocketPool.ConnectionTimeout = new TimeSpan(0, 0, 4);
            cbcc.SocketPool.DeadTimeout = new TimeSpan(0, 0, 10);
            //使用默认的数据库   
            cbcc.Urls.Add(new Uri("http://127.0.0.1:8091/pools/default"));
            //建立一个Client，装入Client的配置   
            CouchbaseClient client = new CouchbaseClient(cbcc);
            //添加一条数据 
            //CasResult<bool> casResult = client.Cas(StoreMode.Add, "Test", "Hello World!");
            //获取刚添加的数据   
            Console.WriteLine(client.Get("key_1"));
            Console.WriteLine("完成！");
            Console.ReadLine();
            //InitTaskList();
            //TestMethod();
            //InstanceContext instanceContext = new InstanceContext(new CalculateCallback());
            //using (
            //    DuplexChannelFactory<ICalculator> channelFactory = new DuplexChannelFactory<ICalculator>(
            //        instanceContext, "CalculatorService"))
            //{
            //    ICalculator proxy = channelFactory.CreateChannel();
            //    using (proxy as IDisposable)
            //    {
            //        proxy.Add1(1, 2);
            //        Console.Read();
            //    }
            //}
        }

        /// <summary>
        /// 初始化对象列表
        /// </summary>
        static void InitTaskList()
        {
            taskList = new List<TestTask>();
            for (int i = 0; i < maxThread; i++)
            {
                taskList.Add(new TestTask(i));
            }
        }

        /// <summary>
        /// 初始化测试开始前的数据环境
        /// </summary>
        static void InitData()
        {
            isWorking = true;
            startTime = DateTime.Now;
            counter = 0;
        }

        /// <summary>
        /// 显示测试信息
        /// </summary>
        /// <param name="id">线程ID</param>
        /// <param name="time">随机出的时间</param>
        static void ShowInfo(int id, int time)
        {
            var ts = DateTime.Now - startTime;
            var cps = counter / ts.TotalSeconds;
            //Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            //    new Action(() => InfoText.Text =
            //    $"[共运行{ts.TotalSeconds}秒，每秒接收 {cps} 次]  线程{id}收到{time}!\n"));
            Console.WriteLine(string.Format("[共运行{0}秒，每秒接收 {1} 次]  线程{2}收到{3}!\n", ts.TotalSeconds, cps, id, time));
        }

        #region 保持线程的并发

        static void TestMethod()
        {
            InitData();
            for (int i = 0; i < maxThread; i++)
            {
                var task = new TestTask(i);
                new Thread(ThreadFunction) { IsBackground = true }
                .Start(task);
            }
        }
        //线程函数
        static void ThreadFunction(object o)
        {
            var t = o as TestTask;
            while (isWorking)
            {
                var time = t.ReceiveData();
                counter++;
                if (time != -1)
                {
                    ShowInfo(t.TaskId, time);
                }
                Thread.Sleep(sleepTime);
            }
        }
        #endregion
    }
}
