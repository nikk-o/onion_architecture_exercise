using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WordCounter.Application;
using WordCounter.Infrastructure;
using WordCounter.Domain;
using WordCounter.DependencyInjection.Application;
using WordCounter.DependencyInjection.Domain;
using WordCounter.DependencyInjection.Infrastructure;

namespace WordCounter.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDomainServices();
            services.AddInfrastructureServices();
            services.AddApplicationServices();
        }

        public static IEnumerable<Assembly> GetAssemblies()
        {
            return new Assembly[]
            {
                GetInfrastructureAssembly(),
                GetApplicationAssembly(),
                GetDomainAssembly()
            };
        }

        public static Assembly GetInfrastructureAssembly()
        {
            return typeof(InfrastructureAssemblyHook).Assembly;
        }

        public static Assembly GetApplicationAssembly()
        {
            return typeof(ApplicationAssemblyHook).Assembly;
        }

        public static Assembly GetDomainAssembly()
        {
            return typeof(DomainAssemblyHook).Assembly;
        }
    }
}
