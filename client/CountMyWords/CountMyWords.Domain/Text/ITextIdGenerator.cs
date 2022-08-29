using CountMyWords.Domain.Common;

namespace CountMyWords.Domain.Text
{
    public interface ITextIdGenerator : IIdGenerator
    {
        Guid GenerateNext();
    }
}
