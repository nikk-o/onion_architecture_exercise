using CountMyWords.Domain.Text;

namespace CountMyWords.Infrastructure.IdGenerators
{
    public class TextGuidGenerator : ITextIdGenerator
    {
        public Guid GenerateNext()
        {
            return Zaabee.SequentialGuid.SequentialGuidHelper.GenerateComb();
        }
    }
}
