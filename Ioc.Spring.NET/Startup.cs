using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ioc.Spring.NET.Startup))]
namespace Ioc.Spring.NET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
