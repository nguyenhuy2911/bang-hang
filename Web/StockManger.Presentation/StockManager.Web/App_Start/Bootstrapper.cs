using StockManager.Web.Framework;
using StockManager.Web.Mapping;
using System.Reflection;
namespace StockManager.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            
            var assembly = Assembly.GetExecutingAssembly();
            DependencyRegistrar.Register(assembly);
            AutoMapperConfiguration.Configure();
        }
    }

    
}