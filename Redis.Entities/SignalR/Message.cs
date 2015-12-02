using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Entities.SignalR
{
    public class Message
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Duration { get; set; }
    }
}
