using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Ioc.SignalRMvc
{
    public class MyFirstHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}