using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Core.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<long> BlogIds { get; set; }
        public UserEntity()
        {
            BlogIds = new List<long>();
        }
    }
}
