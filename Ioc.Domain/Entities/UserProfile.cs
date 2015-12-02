using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Domain.Entities
{
    public class UserProfile
    {
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime? AddedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string IP { get; set; }
    }
}
