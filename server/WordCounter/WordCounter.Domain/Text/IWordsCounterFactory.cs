using WordCounter.Domain.Common;

namespace WordCounter.Domain.Text
{
    public interface IWordsCounterFactory : IFactory
    {
        IWordsCounter CreateWordsCounter(WordsCounterType type);
    }
}
