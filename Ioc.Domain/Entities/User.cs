using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Domain.Entities
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime? AddedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string IP { get; set; }
    }
}
