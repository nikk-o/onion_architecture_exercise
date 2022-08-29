using WordCounter.Domain.Text.ReadModels;

namespace WordCounter.Domain.Text
{
    // Counts the number of the words inside string separated by some common delimiters
    internal class AllWordsCounter : IWordsCounter
    {
        public WordsCounterResult CountWords(string text)
        {
            // TODO: Try doing this without split()

            var count = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Length;

            return new WordsCounterResult(count);
        }
    }
}
