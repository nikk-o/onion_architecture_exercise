using FluentValidation;
using CountMyWords.Application.Text.Queries.RequestResponse;

namespace CountMyWords.Infrastructure.Validators.Text.Queries
{
    public class BrowseTextQueryValidator : AbstractValidator<BrowseTextQuery>
    {
        public BrowseTextQueryValidator()
        {
            RuleFor(e => e.Page)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Page should be >= 0.");

            RuleFor(e => e.PageSize)
                .GreaterThan(0)
                .WithMessage("Page size should be > 0.");
        }
    }
}
