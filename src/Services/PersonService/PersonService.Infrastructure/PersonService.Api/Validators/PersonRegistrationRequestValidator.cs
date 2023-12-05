using System;
using PersonService.Application.Services.Dto.PersonDto;
using FluentValidation;

namespace PersonService.Api.Validators;

public class PersonRegistrationRequestValidator : AbstractValidator<PersonRegisterRequest>
{
    public PersonRegistrationRequestValidator()
    {
        RuleFor(c => c).SetValidator(new BasePersonValidator());
        RuleFor(c => c.ProfileCreatedDate).NotEqual(default(DateOnly));
    }
}