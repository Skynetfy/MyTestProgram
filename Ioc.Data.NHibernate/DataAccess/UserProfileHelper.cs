using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ioc.Domain.Entities;
using NHibernate;
using NHibernate.Linq;

namespace Ioc.Data.NHibernate.DataAccess
{
    public  class UserProfileHelper
    {
        /// <summary>
        /// 根据条件得到客户信息集合
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>客户信息集合</returns>
        public IList<UserProfile> GetUserProfileList(Expression<Func<UserProfile, bool>> where)
        {
            try
            {
                NHibernateHelper nhibernateHelper = new NHibernateHelper();
                ISession session = nhibernateHelper.GetSession();
                return session.Query<UserProfile>().Where(where).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
