using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ioc.WebUI.Startup))]
namespace Ioc.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
