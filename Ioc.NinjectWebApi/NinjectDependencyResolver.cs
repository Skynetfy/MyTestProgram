using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ioc.Data.Redis;
using Ioc.Data.Redis.Repository;
using Ninject;
using ServiceStack.Redis;


namespace Ioc.NinjectWebApi
{
    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;
        public IRedisClientsManager ClientsManager;
        private const string RedisUri = "localhost";

        public NinjectDependencyResolver()
        {
            ClientsManager = new PooledRedisClientManager(RedisUri);

            this.kernel = new StandardKernel();
            this.AddBindings();
        }
        private void AddBindings()
        {
            this.kernel.Bind<IUserRepository>()
                .To<UserRepository>();

            this.kernel.Bind<IBlogRepository>()
               .To<BlogRepository>();

            this.kernel.Bind<IRedisClient>().ToConstant(ClientsManager.GetClient());
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }
    }
}