using CountMyWords.Domain.Common;
using CountMyWords.Domain.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CountMyWords.Infrastructure.Repositories
{
    public class TextRepositoryResolver : ITextRepositoryResolver
    {
        private IServiceProvider serviceProvider;

        public TextRepositoryResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ITextReadonlyRepository ResolveReadonlyRepository(ReadTextFromType readFrom)
        {
            switch (readFrom)
            {
                case ReadTextFromType.Database:
                    return serviceProvider.GetService<TextReadonlyDbRepository>();
                case ReadTextFromType.File:
                    return serviceProvider.GetService<TextReadonlyFileRepository>();
                default:
                    // TODO: Create a more specific exception
                    throw new Exception("Unsupported value of ReadTextFrom Enum.");
            }
        }
    }
}
