using Autofac;
using Autofac.Integration.Mvc;
using StockManager.Business;
using StockManager.Data;
using StockManager.Data.Infrastructure;
using StockManager.Data.Repository;
using StockManager.Web.Framework.Mapping;
using StockManger.Core.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace StockManager.Web.Framework
{
    public static class DependencyRegistrar
    {
        public static void Register(Assembly assembly)
        {
            SetAutofacContainer(assembly);
        }

        private static void SetAutofacContainer(Assembly assembly)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DataBaseFactory>().As<IDataBaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<AppDomainTypeFinder>().As<ITypeFinder>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        
        }
    }
}
