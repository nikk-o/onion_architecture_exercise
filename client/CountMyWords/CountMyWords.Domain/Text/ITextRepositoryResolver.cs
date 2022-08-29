using CountMyWords.Domain.Common;

namespace CountMyWords.Domain.Text
{
    public interface ITextRepositoryResolver : IService
    {
        ITextReadonlyRepository ResolveReadonlyRepository(ReadTextFromType readFrom);
    }

    // Other approach would've been to use a delegate and register its implementation directly inside of the DI container
    //public delegate ITextReadonlyRepository TextReadonlyRepositoryResolver(ReadTextFrom readTextFrom);
}
