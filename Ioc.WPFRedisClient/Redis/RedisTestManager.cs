using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ioc.Core.Entities;
using ServiceStack;
using ServiceStack.Redis;

namespace Ioc.WPFRedisClient.Redis
{
    public class RedisTestManager
    {
        readonly RedisClient redis;
        const string redisConnectStr = "localhost:8122";

        public RedisTestManager()
        {
            redis = new RedisClient(redisConnectStr);
        }

        public void RedisFlushAll()
        {
            redis.FlushAll();
        }

        public void AddData()
        {
            InsertTestData();
        }

        public void InsertTestData()
        {
            var redisUsers = redis.As<UserEntity>();
            var redisBlogs = redis.As<BlogEntity>();
            var redisBlogPosts = redis.As<BlogPostEntity>();

            var yangUser = new UserEntity { Id = redisUsers.GetNextSequence(), Name = "Eric Yang" };
            var zhangUser = new UserEntity { Id = redisUsers.GetNextSequence(), Name = "Fish Zhang" };

            var yangBlog = new BlogEntity
            {
                Id = redisBlogs.GetNextSequence(),
                UserId = yangUser.Id,
                UserName = yangUser.Name,
                Tags = new List<string> { "Architecture", ".NET", "Databases" },
            };

            var zhangBlog = new BlogEntity
            {
                Id = redisBlogs.GetNextSequence(),
                UserId = zhangUser.Id,
                UserName = zhangUser.Name,
                Tags = new List<string> { "Architecture", ".NET", "Databases" },
            };

            var blogPosts = new List<BlogPostEntity>
    {
        new BlogPostEntity
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = yangBlog.Id,
            Title = "Memcache",
            Categories = new List<string> { "NoSQL", "DocumentDB" },
            Tags = new List<string> {"Memcache", "NoSQL", "JSON", ".NET"} ,
            Comments = new List<BlogPostCommentEntity>
            {
                new BlogPostCommentEntity { Content = "First Comment!", CreatedDate = DateTime.UtcNow,},
                new BlogPostCommentEntity { Content = "Second Comment!", CreatedDate = DateTime.UtcNow,},
            }
        },
        new BlogPostEntity
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = zhangBlog.Id,
            Title = "Redis",
            Categories = new List<string> { "NoSQL", "Cache" },
            Tags = new List<string> {"Redis", "NoSQL", "Scalability", "Performance"},
            Comments = new List<BlogPostCommentEntity>
            {
                new BlogPostCommentEntity { Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
            }
        },
        new BlogPostEntity
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = yangBlog.Id,
            Title = "Cassandra",
            Categories = new List<string> { "NoSQL", "Cluster" },
            Tags = new List<string> {"Cassandra", "NoSQL", "Scalability", "Hashing"},
            Comments = new List<BlogPostCommentEntity>
            {
                new BlogPostCommentEntity { Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
            }
        },
        new BlogPostEntity
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = zhangBlog.Id,
            Title = "Couch Db",
            Categories = new List<string> { "NoSQL", "DocumentDB" },
            Tags = new List<string> {"CouchDb", "NoSQL", "JSON"},
            Comments = new List<BlogPostCommentEntity>
            {
                new BlogPostCommentEntity {Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
            }
        },
    };

            yangUser.BlogIds.Add(yangBlog.Id);
            yangBlog.BlogPostIds.AddRange(blogPosts.Where(x => x.BlogId == yangBlog.Id).Map(x => x.Id));

            zhangUser.BlogIds.Add(zhangBlog.Id);
            zhangBlog.BlogPostIds.AddRange(blogPosts.Where(x => x.BlogId == zhangBlog.Id).Map(x => x.Id));

            redisUsers.Store(yangUser);
            redisUsers.Store(zhangUser);
            redisBlogs.StoreAll(new[] { yangBlog, zhangBlog });
            redisBlogPosts.StoreAll(blogPosts);
        }
    }
}
