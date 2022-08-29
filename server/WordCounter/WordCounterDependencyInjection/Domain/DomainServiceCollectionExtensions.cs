using Microsoft.Extensions.DependencyInjection;
using WordCounter.Domain.Common;

namespace WordCounter.DependencyInjection.Domain
{
    public static class DomainServiceCollectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.RegisterInterfaceImplementations(ServiceCollectionExtensions.GetAssemblies(), typeof(IFactory), ServiceLifetime.Scoped);
        }
    }
}
