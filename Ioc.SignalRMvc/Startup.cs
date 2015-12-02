using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ioc.SignalRMvc.Startup))]
namespace Ioc.SignalRMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //JSOP config
            //var config = new ConnectionConfiguration()
            //{
            //    EnableJSONP = true
            //};
            //app.MapSignalR<EchoConnection>("/echo", config);

            //CORS config
            //app.Map("/echo",
            //    map =>
            //    {
            //        map.UseCors(CorsOptions.AllowAll);
            //        map.RunSignalR<EchoConnection>();
            //    });

            // 映射 hubs 默认为"/signalr"
            //app.MapSignalR();
            var hubconfig = new HubConfiguration()
            {
                EnableJavaScriptProxies = true
            };
            //映射Hubs到"/realtime",同时还可以配置HubConfiguration,比如我们uxyao跨域,和上一讲用法是一致
            app.MapSignalR("/realtime", hubconfig);
        }
    }
}
