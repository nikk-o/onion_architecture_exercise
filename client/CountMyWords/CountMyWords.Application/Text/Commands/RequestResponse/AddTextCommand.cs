using MediatR;

namespace CountMyWords.Application.Text.Commands.RequestResponse
{
    public class AddTextCommand : IRequest<AddTextCommandResponse>
    {
        public string Text { get; set; }
    }
}
