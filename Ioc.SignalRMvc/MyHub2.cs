using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Ioc.SignalRMvc
{
    public class MyHub2 : Hub
    {
        private IDictionary<string, string> _userNames;

        public MyHub2()
        {
            //TODO:初始化UserNames
        }

        public void SendMessageByUserName(string userName)
        {
            //取到所有名字为那么的用户
            IList<string> users = _userNames.Where(u => u.Value == userName).Select(u => u.Key).ToList();
            Clients.Clients(users).sendMessage("Hi!");
        }
    }
}