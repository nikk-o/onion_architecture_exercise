using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WordCounter.Application.Validation;

namespace WordCounter.DependencyInjection.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var applicationAssembly = ServiceCollectionExtensions.GetApplicationAssembly();

            services.AddMediatR(applicationAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
        }
    }
}
