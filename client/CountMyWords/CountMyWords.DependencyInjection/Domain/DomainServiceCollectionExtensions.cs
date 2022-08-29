using CountMyWords.Domain.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CountMyWords.DependencyInjection.Domain
{
    public static class DomainServiceCollectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.RegisterInterfaceImplementations(ServiceCollectionExtensions.GetAssemblies(), typeof(IService), ServiceLifetime.Scoped);
            services.RegisterInterfaceImplementations(ServiceCollectionExtensions.GetAssemblies(), typeof(IFactory), ServiceLifetime.Scoped);
            services.RegisterInterfaceImplementations(ServiceCollectionExtensions.GetAssemblies(), typeof(IIdGenerator), ServiceLifetime.Scoped);
        }
    }
}
