using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ioc.Domain.Entities;
using Ioc.Data.NHibernate;
using Ioc.Data.NHibernate.DataAccess;

namespace Ioc.Business
{
    public class UserBusiness
    {
        private UserHelper _userHelper;

        public UserBusiness()
        {
            _userHelper = new UserHelper();
        }
        /// <summary>
        /// 根据条件得到客户信息集合
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>客户信息集合</returns>
        public IList<User> GetCustomerList(Expression<Func<User, bool>> where)
        {
            return _userHelper.GetCustomerList(where);
        }
    }
}
