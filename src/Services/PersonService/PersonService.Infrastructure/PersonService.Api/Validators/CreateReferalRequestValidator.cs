using System;
using System.Text.RegularExpressions;
using PersonService.Application.Services.Dto.ReferralDto;
using FluentValidation;
using GuardExtensions.Primitives;

namespace PersonService.Api.Validators;

public class CreateReferralRequestValidator : AbstractValidator<CreateReferralRequest>
{
    public CreateReferralRequestValidator()
    {
        RuleFor(c => c.ReferralId).NotEqual(default(Guid));
        RuleFor(c => c.PersonName).Must(SpecialCharactersValidation);
        RuleFor(c => c.ReferralName).Must(SpecialCharactersValidation);
    }

    private static bool SpecialCharactersValidation(string input)
    {
        return !Regex.IsMatch(input, RegexPatterns.SpecialCharactersPattern) && !string.IsNullOrEmpty(input);
    }
}