using CountMyWords.Domain.Common;


namespace CountMyWords.Domain.Text
{
    public interface ITextRepository : IRepository
    {
        Task AddAsync(Text text);
    }
}
