using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Redis.Entities.SignalR;

namespace Redis.Core
{
    public class Messenger
    {
        private readonly static Lazy<Messenger> _instance = new Lazy<Messenger>(() => new Messenger());

        private readonly ConcurrentDictionary<string, Message> _messages = new ConcurrentDictionary<string, Message>();

        private Messenger()
        {
        }

        public static Messenger Instance
        {
            get { return _instance.Value; }
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return _messages.Values;
        }

        public void BroadCastMessage(object message,string group)
        {

        }

        private static dynamic GetClients(string group)
        {
            //var context=GlobalHost.ConnectionManager.GetHubContext<()
        }
    }
}
