namespace {{project_name}}.Application.Common.Behaviours;

[ExcludeFromCodeCoverage]
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failure = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .FirstOrDefault();

            if (failure is not null)
                throw new HttpResponseException(HttpStatusCode.BadRequest, failure.ErrorMessage, false);

        }
        return await next();
    }
}