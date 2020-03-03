using FluentValidation;
using FullTimeForceTest.Api.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Infrastructure.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehavior(IValidator<TRequest>[] validators) => _validators = validators;

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                  .Select(v => v.Validate(request))
                  .SelectMany(result => result.Errors)
                  .Where(error => error != null)
                  .ToList();

            if (failures.Any())
            {
                var errors = string.Join(",", failures.Select(x => x.ErrorMessage).ToArray());
                throw new ApiException(
                    $"Command {typeof(TRequest).Name} => {errors}", new ValidationException("Validation exception", failures));
            }

            var response = await next();
            return response;
        }
    }
}
