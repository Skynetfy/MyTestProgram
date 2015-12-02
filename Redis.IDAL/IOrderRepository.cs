using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redis.Entities;

namespace Redis.IDAL
{
    public interface IOrderRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        IList<Order> GetCustomerOrders(Guid customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        IList<Order> StoreAll(Customer customer, IList<Order> orders);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Order Store(Customer customer, Order order);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        IDictionary<string, double> GetBestSellingItems(int count);

    }
}
