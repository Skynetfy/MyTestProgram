using System;
using System.Collections.Generic;
using System.Linq;
using Redis.Entities;
using Redis.IDAL;
using ServiceStack.Redis;

namespace Redis.DAL
{
    public class OrderRepository : IOrderRepository
    {

        private readonly IRedisClient _redisClient;

        public OrderRepository(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        public IList<Order> GetCustomerOrders(Guid customerId)
        {
            var orderClient = _redisClient.As<Order>();

            var orderIds = _redisClient.GetAllItemsFromSet(RedisKeys
                       .GetCustomerOrdersReferenceKey(customerId));

            IList<Order> orders = orderClient.GetByIds(orderIds);

            return orders;
        }

        public Order Store(Customer customer, Order order)
        {
            IList<Order> result = StoreAll(customer, new List<Order>() { order });
            return result.FirstOrDefault();
        }

        public IDictionary<string, double> GetBestSellingItems(int count)
        {
            return _redisClient
                .GetRangeWithScoresFromSortedSetDesc(RedisKeys.BestSellingItems,
                0, count - 1);
        }

        public IList<Order> StoreAll(Customer customer, IList<Order> orders)
        {
            foreach (var order in orders)
            {
                if (order.Id == default(Guid))
                {
                    order.Id = Guid.NewGuid();
                }
                order.UserId = customer.Id;
                if (!customer.Orders.Contains(order.Id))
                {
                    customer.Orders.Add(order.Id);
                }

                foreach (var x in order.Lines)
                    _redisClient
                        .IncrementItemInSortedSet(RedisKeys.BestSellingItems,
                            (string) x.Item, (long) x.Quantity);

            }
            var orderIds = orders.Select(o => o.Id.ToString()).ToList();
            using (var transaction = _redisClient.CreateTransaction())
            {
                transaction.QueueCommand(c => c.Store(customer));
                transaction.QueueCommand(c => c.StoreAll(orders));
                transaction.QueueCommand(c => c.AddRangeToSet(RedisKeys
                    .GetCustomerOrdersReferenceKey(customer.Id),
                    orderIds));
                transaction.Commit();
            }

            return orders;
        }
    }
}
