using AutoMapper;
using MediatR;

using WordCounter.Application.Text.Commands.RequestResponse;
using WordCounter.Domain.Text;
using WordCounter.Domain.Text.ReadModels;

namespace WordCounter.Application.Text.Commands
{
    // A use case where the words are counted in the received text
    // Depending on the WordsCounterType value, we either count all words or just the ones starting with a capital letter
    public class CountWordsCommandHandler : IRequestHandler<CountWordsCommand, CountWordsCommandResponse>
    {
        private readonly IWordsCounterFactory wordsCounterFactory;
        private readonly IMapper mapper;

        public CountWordsCommandHandler(IWordsCounterFactory wordsCounterFactory, IMapper mapper)
        {
            this.wordsCounterFactory = wordsCounterFactory;
            this.mapper = mapper;
        }

        public Task<CountWordsCommandResponse> Handle(CountWordsCommand request, CancellationToken cancellationToken)
        {
            var wordsCounter = wordsCounterFactory.CreateWordsCounter(request.WordsCounterType);

            var countResult = wordsCounter.CountWords(request.Text);

            return Task.FromResult(mapper.Map<WordsCounterResult, CountWordsCommandResponse>(countResult));
        }
    }
}
