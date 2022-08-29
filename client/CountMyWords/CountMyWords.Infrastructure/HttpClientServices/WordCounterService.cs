using CountMyWords.Domain.Common;
using CountMyWords.Domain.Text;
using CountMyWords.Infrastructure.HttpClientServices.Options;
using CountMyWords.Infrastructure.HttpClientServices.Requests;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace CountMyWords.Infrastructure.HttpClientServices
{
    // A simple HttpClient wrapper service
    public class WordCounterService : IWordCounterService
    {
        private readonly HttpClient httpClient;
        private readonly WordCounterServiceOptions options;

        public WordCounterService(HttpClient httpClient, IOptions<WordCounterServiceOptions> options)
        {
            this.httpClient = httpClient;
            this.options = options.Value;
        }

        public async Task<int> CountWords(string text)
        {
            var request = new WordCounterRequest
            {
                Text = text,
                WordsCounterType = WordsCounterType.All
            };

            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(options.Url, data);
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            // TODO: Handle error response

            var response = JsonConvert.DeserializeObject<WordCounterResponse>(stringResponse);

            return response.Count;
        }
    }
}
