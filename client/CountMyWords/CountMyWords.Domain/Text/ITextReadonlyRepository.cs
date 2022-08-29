using CountMyWords.Domain.Common;
using CountMyWords.Domain.Text.Read;

namespace CountMyWords.Domain.Text
{
    public interface ITextReadonlyRepository : IRepository
    {
        public Task<TextReadModel> GetReadModelAsync(Guid id);
        public Task<IEnumerable<TextReadModel>> BrowseTextReadModelsAsync(int page, int pageSize);
    }
}
