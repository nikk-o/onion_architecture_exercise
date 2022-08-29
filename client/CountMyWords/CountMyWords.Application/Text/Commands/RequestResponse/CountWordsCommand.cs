using CountMyWords.Domain.Common;
using MediatR;

namespace CountMyWords.Application.Text.Commands.RequestResponse
{
    public class CountWordsCommand : IRequest<CountWordsCommandResponse>
    {
        public Guid Id { get; set; }

        public ReadTextFromType ReadFrom { get; set; }
        
    }
}
