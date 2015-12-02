using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheLibrary
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    interface ICacheManager
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool AddCache(string key, object value);

        /// <summary>
        /// 添加缓存带缓存过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts">缓存过期时间</param>
        /// <returns></returns>
        bool AddCache(string key, object value, TimeSpan ts);

        /// <summary>
        /// 环球缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetCache<T>(string key) where T : class;

        /// <summary>
        /// 获取chache集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        IEnumerable<T> GetAllCache<T>(string key) where T : class;
        /// <summary>
        /// 修改指定key的缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Update<T>(string key, T obj) where T : class;

        /// <summary>
        /// 删除指定key的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Delete(string key);

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        /// <returns></returns>
        void ClearAll();
    }
}
