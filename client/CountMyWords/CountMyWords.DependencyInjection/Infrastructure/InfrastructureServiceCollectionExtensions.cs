using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CountMyWords.Infrastructure.Database;
using CountMyWords.Infrastructure.Repositories;
using CountMyWords.Domain.Common;
using CountMyWords.Domain.Text;
using CountMyWords.Infrastructure.HttpClientServices.Options;
using CountMyWords.Infrastructure.Repositories.Options;

namespace CountMyWords.DependencyInjection.Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureOptions(configuration);

            var infrastructureAssembly = ServiceCollectionExtensions.GetInfrastructureAssembly();
            services.AddAutoMapper(infrastructureAssembly);
            services.AddValidatorsFromAssembly(infrastructureAssembly);

            services.AddHttpClient();

            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITextRepository, TextRepository>();
            
            // Use this by default
            services.AddScoped<ITextReadonlyRepository, TextReadonlyDbRepository>();
            services.AddScoped<TextReadonlyDbRepository>();
            services.AddScoped<TextReadonlyFileRepository>();

            // Could've used a delegate instead of ITextRepositoryResolver interface
            //services.AddScoped<TextReadonlyRepositoryResolver>(serviceProvider => readFrom =>
            //{
            //    switch (readFrom)
            //    {
            //        case ReadTextFrom.Database:
            //            return serviceProvider.GetService<TextReadonlyDbRepository>();
            //        case ReadTextFrom.File:
            //            return serviceProvider.GetService<TextReadonlyFileRepository>();
            //        default:
            //            throw new Exception("Unsupported ReadTextFrom Enum value.");
            //    }
            //});
        }

        public static void AddInfrastructureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<WordCounterServiceOptions>(configuration.GetSection("WordCounterServiceOptions")); // TODO: Remove magic string
            services.Configure<FileRepositoryOptions>(configuration.GetSection("FileRepositoryOptions")); // TODO: Remove magic string

        }
    }
}
