using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ioc.Core.Entities;
using Ioc.Data.Redis;

namespace Ioc.NinjectWebApi.Controllers
{
    public class TestController : ApiController
    {
         private IUserRepository userRepository { get; set; }
        private IBlogRepository blogRepository { get; set; }

        public TestController()
        {

        }

        public TestController(IUserRepository r, IBlogRepository d)
        {
            userRepository = r;
            blogRepository = d;
        }
        public IQueryable<UserEntity> GetAll()
        {
            return userRepository.GetAll().AsQueryable();
        }

        public UserEntity Get(long id)
        {
            var customer = userRepository.GetEntity(id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }
        [HttpGet]
        public HttpResponseMessage Post()
        {
            UserEntity customer = new UserEntity()
            {
                Id = 1,
                Name = "张三",
                BlogIds = new List<long>()
                {
                    1,2,4,5,6
                }
            };
            var result = userRepository.Store(customer);
            return Request.CreateResponse(HttpStatusCode.Created, result);
        }
        [HttpGet]
        public HttpResponseMessage Put(long id)
        {
            var existingEntity = userRepository.GetEntity(id);
            if (existingEntity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            existingEntity.Id = id;
            userRepository.Store(existingEntity);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
