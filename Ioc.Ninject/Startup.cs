using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ioc.Ninject.Startup))]
namespace Ioc.Ninject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
