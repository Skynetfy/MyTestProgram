using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Spring.Net.App1
{
    public class ModernPerson : Peaple
    {
        /// <summary>
        /// 从外部获取工具
        /// </summary>
        public ITool Tool { get; set; }

        /// <summary>
        /// 现在人用不需要知道电脑是哪来的，直接拿来办公
        /// </summary>
        public override void Work()
        {
            //不知道使用什么工具和哪来的工具，只是机械化的办公
            Tool.UseTool();
            Console.WriteLine("使用工具办公");
        }
    }
}
