using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Spring.Net.App1
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class StudentDao
    {
        private int intProp;

        public StudentDao(int intProp)
        {
            this.intProp = intProp;
        }

        public Student Entity { get; set; }

        public override string ToString()
        {
            return "构造函数参数intProp为：" + this.intProp;
        }
    }
}
