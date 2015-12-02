using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Core.Entities
{
    public class BlogPostEntity : BaseEntity
    {
        public long BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Tags { get; set; }
        public List<BlogPostCommentEntity> Comments { get; set; }

        public BlogPostEntity()
        {
            Categories = new List<string>();
            Tags = new List<string>();
            Comments = new List<BlogPostCommentEntity>();
        }
    }
}
