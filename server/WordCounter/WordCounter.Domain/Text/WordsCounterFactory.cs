namespace WordCounter.Domain.Text
{
    public class WordsCounterFactory : IWordsCounterFactory
    {
        public IWordsCounter CreateWordsCounter(WordsCounterType type)
        {
            switch (type)
            {
                case WordsCounterType.All:
                    return new AllWordsCounter();
                case WordsCounterType.Capital:
                    return new CapitalWordsCounter();
                default:
                    throw new Exception("Unsupported words counter type.");
            }
        }
    }
}
