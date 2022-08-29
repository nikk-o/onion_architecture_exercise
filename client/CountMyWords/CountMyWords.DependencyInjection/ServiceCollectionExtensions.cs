using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CountMyWords.Application;
using CountMyWords.Infrastructure;
using CountMyWords.DependencyInjection.Application;
using CountMyWords.DependencyInjection.Domain;
using CountMyWords.DependencyInjection.Infrastructure;
using CountMyWords.Domain;

namespace CountMyWords.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDomainServices();
            services.AddInfrastructureServices(configuration);
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
