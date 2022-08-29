using CountMyWords.Domain.Text;
using CountMyWords.Domain.Text.Read;
using CountMyWords.Infrastructure.Database;
using CountMyWords.Infrastructure.Records;
using Microsoft.EntityFrameworkCore;

namespace CountMyWords.Infrastructure.Repositories
{
    public class TextReadonlyDbRepository : ITextReadonlyRepository
    {
        private DatabaseContext context;

        public TextReadonlyDbRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<TextReadModel> GetReadModelAsync(Guid id)
        {
            var record = await context.Texts
                .FirstOrDefaultAsync(e => e.Id == id);

            return record == null ? null : GetTextReadModel(record);
        }

        // Expects valid arguments
        public async Task<IEnumerable<TextReadModel>> BrowseTextReadModelsAsync(int page, int pageSize)
        {
            var query = context.Texts.AsQueryable();

            if(page == 1)
            {
                query = query.Take(pageSize);
            }
            else
            {
                query = query.Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            var records = await query.ToListAsync();

            return records.Select(GetTextReadModel);
        }

        private TextReadModel GetTextReadModel(TextRecord record)
        {
            return new TextReadModel(record.Id, record.Value);
        }
    }
}
