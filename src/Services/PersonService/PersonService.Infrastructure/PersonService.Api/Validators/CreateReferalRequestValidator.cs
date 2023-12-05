using System;
using System.Text.RegularExpressions;
using PersonService.Application.Services.Dto.ReferalDto;
using FluentValidation;
using GuardExtensions.Primitives;

namespace PersonService.Api.Validators;

public class CreateReferalRequestValidator : AbstractValidator<CreateReferalRequest>
{
    public CreateReferalRequestValidator()
    {
        RuleFor(c => c.ReferalId).NotEqual(default(Guid));
        RuleFor(c => c.PersonName).Must(SpecialCharactersValidation);
        RuleFor(c => c.ReferalName).Must(SpecialCharactersValidation);
    }

    private static bool SpecialCharactersValidation(string input)
    {
        return !Regex.IsMatch(input, RegexPatterns.SpecialCharactersPattern) && !string.IsNullOrEmpty(input);
    }
}