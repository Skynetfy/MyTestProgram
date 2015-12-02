using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Enyim.Caching.Memcached;
using Newtonsoft.Json;

namespace CacheLibrary
{
    public class CouchbaseCacheFactory : ICacheManager
    {
        const string _bucketName = "default";
        const string _bucketPassword = "";

        //创建一个静态的只读对象(用于下面的加锁)
        private static readonly object SyncRoot = new object();
        #region 缓存工厂的基础属性字段,静态构造方法

        private static readonly CouchbaseClient _instance;

        //静态构造函数，在类初始化的时候执行，不用加 public / private 没有意义,因为这个是由.net自动来调用  
        static CouchbaseCacheFactory()
        {
            _instance = new CouchbaseClient(_bucketName, _bucketPassword);
        }

        private static CouchbaseClient Instance
        {
            get { return _instance; }
        }

        #endregion

        #region 工厂单利
        private static CouchbaseCacheFactory _shareInstance;

        public static CouchbaseCacheFactory GetCurrentCache()
        {
            if (_shareInstance == null)
            {
                lock (SyncRoot)
                {
                    _shareInstance = new CouchbaseCacheFactory();
                }
            }
            return _shareInstance;
        }

        #endregion

        #region CRUD 接口的实现

        /// <summary>
        /// 添加缓存，县序列化对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddCache(string key, object obj)
        {
            //注意:如果直接使用object来保存,则Couchbase缓存会帮我们自动加密(Base64)
            //如果先序列化后,再保存,那么就不会加密
            string strJson = JsonConvert.SerializeObject(obj);
            return Instance.Store(StoreMode.Set, key, strJson);
        }

        /// <summary>
        /// 添加缓存带过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public bool AddCache(string key, object obj, TimeSpan ts)
        {
            string strJson = JsonConvert.SerializeObject(obj);
            return Instance.Store(StoreMode.Set, key, strJson, ts);
        }

        /// <summary>
        /// 获取指定key的缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetCache<T>(string key) where T : class
        {
            string strJson = Instance.Get<string>(key);
            return string.IsNullOrEmpty(strJson) ? null : (T)JsonConvert.DeserializeObject(strJson, typeof(T));
        }

        public IEnumerable<T> GetAllCache<T>(string key) where T : class
        {
            string strJson = Instance.Get<string>(key);
            return string.IsNullOrEmpty(strJson) ? null : (IEnumerable<T>)JsonConvert.DeserializeObject(strJson, typeof(IEnumerable<T>));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update<T>(string key, T obj) where T : class
        {
            string strJson = JsonConvert.SerializeObject(obj);
            return Instance.Store(StoreMode.Set, key, strJson);
        }

        /// <summary>
        /// 删除指定key的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(string key)
        {
            return Instance.Remove(key);
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public void ClearAll()
        {
            Instance.FlushAll();
        }

        #endregion
    }
}
