using CountMyWords.Domain.Common;

namespace CountMyWords.Infrastructure.HttpClientServices.Requests
{
    public class WordCounterRequest
    {
        public string Text { get; set; }

        public WordsCounterType WordsCounterType { get; set; }
    }
}
