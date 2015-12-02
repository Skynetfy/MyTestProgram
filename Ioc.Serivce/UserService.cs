using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ioc.Core.Data;
using Ioc.Data.Repository;

namespace Ioc.Serivce
{
    public class UserService : IUserService
    {
        private IBaseRepository<User> userRepository;
        private IBaseRepository<UserProfile> userProfileRepository;

        public UserService(IBaseRepository<User> userRe, IBaseRepository<UserProfile> userPre)
        {
            this.userProfileRepository = userPre;
            this.userRepository = userRe;
        }
        public IQueryable<User> GetUsers()
        {
            return userRepository.Table;
        }

        public User GetUser(long id)
        {
            return userRepository.GetById(id);
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            userProfileRepository.Delete(user.UserProfile);
            userRepository.Delete(user);
        }
    }
}
