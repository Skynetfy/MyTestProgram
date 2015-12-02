using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetWCF
{
    public class WcfContract : IWcfContract
    {
        public string GetData(string value)
        {
            return string.Format("你输入的是：{0}", value);
        }
    }
}
