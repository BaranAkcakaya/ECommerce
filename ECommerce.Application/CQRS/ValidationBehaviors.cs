using FluentValidation;
using MediatR;

namespace ECommerce.Application.CQRS
{
    public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validation;

        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validation)
        {
            _validation = validation;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validation
                .Select(x => x.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .AsEnumerable();

            if (failures.Any())
                throw new ValidationException(failures);

            return next();
        }
    }
}
