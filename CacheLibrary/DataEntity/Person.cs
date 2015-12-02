using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheLibrary.DataEntity
{
    public class Person
    {
        public Guid Gid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public SexEnum Sex { get; set; }
    }

    public enum SexEnum
    {
        男 = 0,
        女 = 2,
        人妖 = -1
    }
}
