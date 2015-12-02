using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.DAL
{
    public static class RedisKeys
    {
        public static string BestSellingItems = "urn:BestSellingItems";
        public static string CustomerOrders = "urn:CustomerOrders";

        public static string GetCustomerOrdersReferenceKey(Guid customerId)
        {
            return String.Format("{0}_{1}", CustomerOrders, customerId.ToString());
        }
    }
}
