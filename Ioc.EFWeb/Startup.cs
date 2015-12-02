using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ioc.EFWeb.Startup))]
namespace Ioc.EFWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
