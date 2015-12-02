using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Services
{
    public class UserInfoService : IUserInfo
    {
        public string GetUserInfo()
        {
            return "这是一个用户";
        }
    }
}
