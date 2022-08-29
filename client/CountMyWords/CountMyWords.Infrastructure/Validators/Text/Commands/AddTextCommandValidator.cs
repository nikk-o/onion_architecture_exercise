using FluentValidation;
using CountMyWords.Application.Text.Commands.RequestResponse;

namespace CountMyWords.Infrastructure.Validators.Text.Commands
{
    public class AddTextCommandValidator : AbstractValidator<AddTextCommand>
    {
        public AddTextCommandValidator()
        {
            RuleFor(e => e.Text)
                .NotNull()
                .NotEmpty()
                .WithMessage("Text shouldn't be null or empty.");
        }
    }
}
