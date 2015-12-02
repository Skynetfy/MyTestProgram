using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ioc.Core.Entities;
using ServiceStack.Redis;

namespace Ioc.Data.Redis.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private IRedisClient _redisClient;

        public UserRepository(IRedisClient redisClient) : base(redisClient)
        {
            _redisClient = redisClient;
        }
    }
}
