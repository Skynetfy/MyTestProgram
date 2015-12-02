using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Spring.Net.App1
{
    public class Computer:ITool
    {
        public void UseTool()
        {
            Console.WriteLine("使用电脑");
        }
    }
}
