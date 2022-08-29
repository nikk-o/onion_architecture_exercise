using MediatR;

using WordCounter.Domain.Text;

namespace WordCounter.Application.Text.Commands.RequestResponse
{
    public class CountWordsCommand : IRequest<CountWordsCommandResponse>
    {
        public string Text { get; set; }

        // TODO: Validation
        public WordsCounterType WordsCounterType { get; set; }
    }
}
