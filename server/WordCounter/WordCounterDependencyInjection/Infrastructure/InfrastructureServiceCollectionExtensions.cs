using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace WordCounter.DependencyInjection.Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            var infrastructureAssembly = ServiceCollectionExtensions.GetInfrastructureAssembly();
            services.AddAutoMapper(infrastructureAssembly);
            services.AddValidatorsFromAssembly(infrastructureAssembly);
        }
    }
}
