using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ioc.ClaimsBasicMvc.Models
{
    public class BootstrapTableEntity<T> where T:class 
    {
        public int total { get; set; }
        public IList<T> rows { get; set; }
    }
}