using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ioc.Serivce;

namespace Ioc.Ninject.Module
{
    public class MvcModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IUserService>().To<UserService>();
        }
    }
}