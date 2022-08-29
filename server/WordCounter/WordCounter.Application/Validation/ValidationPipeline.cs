using FluentValidation;

using MediatR;

namespace WordCounter.Application.Validation
{
    // Validates the request objects based on the validators that are configured in the Infrastructure project
    // Called before any of IRequestHandlers<,> are triggered
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!validators.Any())
            {
                return await next();
            }

            var validationContext = new ValidationContext<TRequest>(request);

            var errorMessagesDict = validators
                .Select(e => e.Validate(validationContext))
                .SelectMany(e => e.Errors)
                .Where(e => e != null)
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage,
                        (propertyName, errorMessages) => new { Key = propertyName, Values = errorMessages })
                .ToDictionary(e => e.Key, e => e.Values);

            if (errorMessagesDict.Any())
            {
                throw new ValidationException(errorMessagesDict);
            }

            return await next();
        }
    }
}
