using CountMyWords.Domain.Common;


namespace CountMyWords.Domain.Text
{
    public interface IWordCounterService : IService
    {
        // TODO: Make a result object
        Task<int> CountWords(string text);
    }
}
