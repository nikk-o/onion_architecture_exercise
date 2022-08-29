using WordCounter.Domain.Text.ReadModels;

namespace WordCounter.Domain.Text
{
    // Counts the number of the capital words inside string separated by some common delimiters

    internal class CapitalWordsCounter : IWordsCounter
    {
        public WordsCounterResult CountWords(string text)
        {
            // TODO: Try doing this without split()

            var count = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Where(e => char.IsUpper(e[0])).Count();

            return new WordsCounterResult(count);
        }
    }
}
