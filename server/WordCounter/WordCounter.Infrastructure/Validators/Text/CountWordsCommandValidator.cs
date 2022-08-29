using FluentValidation;
using WordCounter.Application.Text.Commands.RequestResponse;

namespace WordCounter.Infrastructure.Validators.Text
{
    public class CountWordsCommandValidator : AbstractValidator<CountWordsCommand>
    {
        public CountWordsCommandValidator()
        {
            RuleFor(e => e.Text)
                .NotNull()
                .WithMessage("Text shouldn't be null.");
        }
    }
}
