using PersonService.Application.Services.Dto.PersonDto;
using FluentValidation;

namespace PersonService.Api.Validators;

public class PersonAuthorizationRequestValidator : AbstractValidator<PersonAuthorizationRequest>
{
    public PersonAuthorizationRequestValidator()
    {
        RuleFor(c => c).SetValidator(new BasePersonValidator());
    }
}