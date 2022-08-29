using WordCounter.Domain.Text.ReadModels;

namespace WordCounter.Domain.Text
{
    public interface IWordsCounter
    {
        WordsCounterResult CountWords(string text);
    }
}
