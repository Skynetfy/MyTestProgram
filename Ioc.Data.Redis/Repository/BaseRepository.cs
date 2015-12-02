using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ioc.Core.Entities;
using ServiceStack.Redis;

namespace Ioc.Data.Redis.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IRedisClient _redisClient;

        public BaseRepository(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        public TEntity GetEntity(long id)
        {
            var typedClient = _redisClient.As<TEntity>();
            return typedClient.GetById(id);
        }

        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        public IList<TEntity> GetAll()
        {
            var typedClient = _redisClient.As<TEntity>();
            return typedClient.GetAll();
        }

        /// <summary>
        /// store entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Store(TEntity entity)
        {
            var typedClient = _redisClient.As<TEntity>();
            return typedClient.Store(entity);
        }

        public void StoreAll(IList<TEntity> list)
        {
            var typedClient = _redisClient.As<TEntity>();
            typedClient.StoreAll(list);
        }
    }
}
