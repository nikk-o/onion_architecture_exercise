using MediatR;
using CountMyWords.Application.Text.Commands.RequestResponse;
using CountMyWords.Domain.Text;
using CountMyWords.Application.Validation;

namespace CountMyWords.Application.Text.Commands
{
    // Gets a text by its Id from the file or the database and counts its number of the words
    public class CountWordsCommandHandler : IRequestHandler<CountWordsCommand, CountWordsCommandResponse>
    {
        private ITextRepositoryResolver textRepositoryResolver;
        private IWordCounterService wordCounterService;

        public CountWordsCommandHandler(ITextRepositoryResolver textRepositoryResolver, IWordCounterService wordCounterService)
        {
            this.textRepositoryResolver = textRepositoryResolver;
            this.wordCounterService = wordCounterService;
        }

        public async Task<CountWordsCommandResponse> Handle(CountWordsCommand request, CancellationToken cancellationToken)
        {
            var textReadonlyRepository = textRepositoryResolver.ResolveReadonlyRepository(request.ReadFrom);
            var text = await textReadonlyRepository.GetReadModelAsync(request.Id);

            if(text == null)
            {
                throw new ValidationException("Text with a provided Id is not found.");
            }

            var count = await wordCounterService.CountWords(text.Value);

            return new CountWordsCommandResponse
            {
                WordCount = count
            };
        }
    }
}
