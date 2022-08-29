namespace WordCounter.Domain.Text.ReadModels
{
    // Immutable class
    public class WordsCounterResult
    {
        public WordsCounterResult(int count)
        {
            Count = count;
        }

        public int Count { get; }
    }
}
