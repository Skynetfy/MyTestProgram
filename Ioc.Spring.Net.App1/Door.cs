using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Spring.Net.App1
{
    //先定义一个委托
    public delegate string OpenHandler(string msg);

    public class Door
    {
        public event OpenHandler OpenTheDoor;

        public void OnOpen(string arg)
        {
            //调用事件
            if (OpenTheDoor != null)
            {
                Console.WriteLine(OpenTheDoor(arg));
            }
        }
    }
    public class Men
    {
        public void ss()
        {
            Door d = new Door();
            d.OpenTheDoor += OpenThisDoor;
            d.OnOpen("a");
        }

        public string OpenThisDoor(string arg)
        {
            return "参数是：" + arg;
        }
    }
}
