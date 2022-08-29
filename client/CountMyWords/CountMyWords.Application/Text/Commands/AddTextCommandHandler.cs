using MediatR;
using CountMyWords.Application.Text.Commands.RequestResponse;
using CountMyWords.Domain.Common;
using CountMyWords.Domain.Text;

namespace CountMyWords.Application.Text.Commands
{
    // Adds a new text to the database
    public class AddTextCommandHandler : IRequestHandler<AddTextCommand, AddTextCommandResponse>
    {
        private ITextFactory textFactory;

        private ITextRepository textRepository;
        private IUnitOfWork unitOfWork;

        public AddTextCommandHandler( ITextFactory textFactory, ITextRepository textRepository, IUnitOfWork unitOfWork)
        {
            this.textFactory = textFactory;
            this.textRepository = textRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<AddTextCommandResponse> Handle(AddTextCommand request, CancellationToken cancellationToken)
        {
            var text = textFactory.Create(request.Text);

            await textRepository.AddAsync(text);
            await unitOfWork.SaveChangesAsync();

            return new AddTextCommandResponse()
            {
                Id = text.Id
            };
        }
    }
}
