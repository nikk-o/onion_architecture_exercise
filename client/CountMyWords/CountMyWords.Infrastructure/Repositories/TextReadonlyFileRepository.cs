using CountMyWords.Domain.Text;
using CountMyWords.Domain.Text.Read;
using CountMyWords.Infrastructure.Repositories.Options;
using Microsoft.Extensions.Options;

namespace CountMyWords.Infrastructure.Repositories
{
    public class TextReadonlyFileRepository : ITextReadonlyRepository
    {
        private readonly string path;

        public TextReadonlyFileRepository(IOptions<FileRepositoryOptions> options)
        {
            path = options.Value.Path;
        }

        public async Task<TextReadModel> GetReadModelAsync(Guid id)
        {
            var line = File.ReadLines(path)
                .Where(e => e.StartsWith(id.ToString()))
                .FirstOrDefault();

            if(line == null)
            {
                return null;
            }

            var substrings = line.Split(new char[] { ' ' }, 2);

            return GetTextReadModel(substrings[0], substrings[1]);
        }


        public async Task<IEnumerable<TextReadModel>> BrowseTextReadModelsAsync(int page, int pageSize)
        {
            var lines = File.ReadLines(path);

            if (page == 1)
            {
                lines = lines.Take(pageSize);
            }
            else
            {
                lines = lines.Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            var models = lines.Select(line => line.Split(new char[] { ' ' }, 2))
                .Select(split => GetTextReadModel(split[0], split[1]));

            return models;
        }
        private TextReadModel GetTextReadModel(string id, string value)
        {
            var guid = Guid.Parse(id);

            return new TextReadModel(guid, value);
        }
    }
}
