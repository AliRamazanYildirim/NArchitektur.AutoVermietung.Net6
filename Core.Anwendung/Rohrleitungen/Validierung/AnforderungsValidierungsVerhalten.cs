using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.Anwendung.Rohrleitungen.Validierung
{
    public class AnforderungsValidierungsVerhalten<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validierungen;

        public AnforderungsValidierungsVerhalten(IEnumerable<IValidator<TRequest>> validierungen)
        {
            _validierungen = validierungen;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            ValidationContext<object> context = new(request);
            List<ValidationFailure> ausfall = _validierungen
                                               .Select(validator => validator.Validate(context))
                                               .SelectMany(result => result.Errors)
                                               .Where(failure => failure != null)
                                               .ToList();
            if (ausfall.Count != 0) throw new ValidationException(ausfall);
            return next();
        }
    }
}
