using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Ioc.Domain.Entities;

namespace Ioc.Data.NHibernate.DataAccess
{
    public class UserHelper
    {
        /// <summary>
        /// 根据条件得到客户信息集合
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>客户信息集合</returns>
        public IList<User> GetCustomerList(Expression<Func<User, bool>> where)
        {
            try
            {
                NHibernateHelper nhibernateHelper = new NHibernateHelper();
                ISession session = nhibernateHelper.GetSession();
                return session.Query<User>().Where(where).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
