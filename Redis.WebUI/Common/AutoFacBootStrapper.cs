using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Redis.DAL;
using Redis.IDAL;
using ServiceStack.Redis;

namespace Redis.WebUI.Common
{
    public class AutoFacBootStrapper
    {

        public static IRedisClientsManager ClientsManager;
        private const string RedisUri = "localhost";

        public static void AutoFacInit()
        {
            var builder = new ContainerBuilder();

            //注册redis客户端
            builder.Register<IRedisClientsManager>(c => new PooledRedisClientManager(RedisUri)
            {
                ConnectTimeout = 100,
                //...
             });

            //注册DomainServices
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
            //.PropertiesAutowired();

            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .PropertiesAutowired();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .PropertiesAutowired();
            //var services1 = Assembly.Load("Redis.DAL");
            //var services2 = Assembly.Load("Redis.IDAL");
            //builder.RegisterAssemblyTypes(services1, services2)
            //  .Where(t => t.Name.EndsWith("Repository"))
            //  .AsImplementedInterfaces().PropertiesAutowired();
            ////实现插件Controllers注入
            //var assemblies = new DirectoryInfo(
            //         HttpContext.Current.Server.MapPath("~/App_Data/Plugins/"))
            //   .GetFiles("*.dll")
            //   .Select(r => Assembly.LoadFrom(r.FullName)).ToArray();
            //foreach (var assembly in assemblies)
            //{
            //    builder.RegisterControllers(assembly).PropertiesAutowired();
            //}
            //注册主项目的Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}