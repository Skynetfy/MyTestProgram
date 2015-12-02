using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Entities
{
    public class OrderLine
    {

        public string Item { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }

    }
}
