using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Core.Entities
{
    public class BlogEntity : BaseEntity
    {
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Tags { get; set; }
        public List<long> BlogPostIds { get; set; }

        public BlogEntity()
        {
            Tags = new List<string>();
            BlogPostIds = new List<long>();
        }
    }
}
