using CountMyWords.Domain.Text;
using CountMyWords.Infrastructure.Database;
using CountMyWords.Infrastructure.Records;

namespace CountMyWords.Infrastructure.Repositories
{
    public class TextRepository : ITextRepository
    {
        private readonly DatabaseContext context;

        public TextRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Text text)
        {
            var record = GetTextRecord(text);

            await context.Texts.AddAsync(record);
        }

        private TextRecord GetTextRecord(Text text)
        {
            return new TextRecord
            {
                Id = text.Id,
                Value = text.Value
            };
        }
    }
}
