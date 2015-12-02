using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ioc.Data.NHibernate.DataAccess;
using Ioc.Domain.Entities;

namespace Ioc.Business
{
    public class UserProfileBusiness
    {
        private UserProfileHelper _UserProfileHelper;

        public UserProfileBusiness()
        {
            _UserProfileHelper = new UserProfileHelper();
        }

        /// <summary>
        /// 根据条件得到客户信息集合
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>客户信息集合</returns>
        public IList<UserProfile> GeUserProfileList(Expression<Func<UserProfile, bool>> where)
        {
            return _UserProfileHelper.GetUserProfileList(where);
        }
    }
}
