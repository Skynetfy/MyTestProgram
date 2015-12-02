using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Core.Entities
{
    public class BlogPostCommentEntity : BaseEntity
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
