using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Redis.Entities.SignalR;

namespace Redis.Core
{
    public class MessagerHub : Hub
    {
        private readonly Messenger _messenger;

        public MessagerHub()
            : this(Messenger.Instance)
        {
        }

        public MessagerHub(Messenger messager)
        {
            _messenger = messager;
        }

        public void AddToGroup(string group)
        {
            this.Groups.Add(Context.ConnectionId, group);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return _messenger.GetAllMessages();
        }

        public void BroadCastMessage(object message, string group)
        {
            _messenger.BroadCastMessage(message, group);
        }
    }
}
