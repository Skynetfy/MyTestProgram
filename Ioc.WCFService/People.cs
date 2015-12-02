using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ioc.WCFService
{
    public class People : IFly
    {
        public string Fly(string name)
        {
            return name + ", you can fly!";
        }
    }
}