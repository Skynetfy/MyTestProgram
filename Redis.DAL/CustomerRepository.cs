using System;
using System.Collections.Generic;
using Redis.Entities;
using Redis.IDAL;
using ServiceStack.Redis;

namespace Redis.DAL
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly IRedisClient _redisClient;

        public CustomerRepository(IRedisClient redisClient)
        {
            //_redisClient = redisClient;
        }

        public IList<Customer> GetAll()
        {
            var typedClient = _redisClient.As<Customer>();

            return typedClient.GetAll();
        }

        public Customer Get(Guid id)
        {
            var typedClient = _redisClient.As<Customer>();

            return typedClient.GetById(id);
        }

        public Customer Store(Customer customer)
        {
            var typedClient = _redisClient.As<Customer>();

            if (customer.Id == default(Guid))
            {
                customer.Id = Guid.NewGuid();
            }
            return typedClient.Store(customer);
        }

    }
}
