using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ioc.Core.Entities;
using ServiceStack.Redis;

namespace Ioc.Data.Redis.Repository
{
    public class BlogRepository:BaseRepository<BlogEntity>,IBlogRepository
    {
        private IRedisClient _redisClient;

        public BlogRepository(IRedisClient redisClient) : base(redisClient)
        {
            _redisClient = redisClient;
        }
    }
}
