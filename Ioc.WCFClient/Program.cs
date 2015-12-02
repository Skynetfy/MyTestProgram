using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ioc.WCFClient.Data;
using Couchbase;
using Couchbase.Configuration;
using Enyim.Caching.Memcached;


namespace Ioc.WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
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
            CasResult<bool> casResult = client.Cas(StoreMode.Add, "Test", "Hello World!");
            //获取刚添加的数据   
            Console.WriteLine(client.Get("Test"));
            Console.WriteLine("完成！");
            Console.ReadLine();
        }
    }
}
