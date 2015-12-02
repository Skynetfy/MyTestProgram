using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.WCFMSMQ
{
    public class Order : IOrder
    {
        public void Add(string order)
        {
            try
            {
                Console.WriteLine("模拟插入数据库操作！");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
