using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Ioc.Data.Redis;
using Ioc.Data.Redis.Repository;
using ServiceStack.Redis;

namespace Ioc.AutofacWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public IRedisClientsManager ClientsManager;
        private const string RedisUri = "localhost";

        protected void Application_Start()
        {

            ClientsManager = new PooledRedisClientManager(RedisUri);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureDependencyResolver(GlobalConfiguration.Configuration);
        }

        protected void Application_OnEnd()
        {
            ClientsManager.Dispose();
        }

        private void ConfigureDependencyResolver(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .PropertiesAutowired()
                .InstancePerApiRequest();

            builder.RegisterType<BlogRepository>()
                .As<IBlogRepository>()
                .PropertiesAutowired()
                .InstancePerApiRequest();

            builder.Register<IRedisClient>(c => ClientsManager.GetClient())
                .InstancePerApiRequest();

            configuration.DependencyResolver
                = new AutofacWebApiDependencyResolver(builder.Build());
        }

    }
}
