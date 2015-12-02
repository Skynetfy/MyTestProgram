using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redis.Entities;

namespace Redis.IDAL
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get All Customer
        /// </summary>
        /// <returns></returns>
        IList<Customer> GetAll();

        /// <summary>
        /// Get Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Customer Get(Guid id);

        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Customer Store(Customer customer);
    }
}
