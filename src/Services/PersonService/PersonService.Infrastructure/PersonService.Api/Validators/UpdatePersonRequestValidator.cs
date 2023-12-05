using System;
using PersonService.Application.Services.Dto.PersonDto;
using FluentValidation;

namespace PersonService.Api.Validators;

public class UpdatePersonRequestValidator : AbstractValidator<UpdatePersonRequest>
{
    public UpdatePersonRequestValidator()
    {
        RuleFor(c => c.Id).NotEqual(default(Guid));
        RuleFor(c => c.Email).EmailAddress();
        RuleFor(c => c).SetValidator(new BasePersonValidator());
    }
}