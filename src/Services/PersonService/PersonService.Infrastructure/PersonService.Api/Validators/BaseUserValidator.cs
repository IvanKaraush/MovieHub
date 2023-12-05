using System.Text.RegularExpressions;
using PersonService.Application.Services.Dto.PersonDto;
using FluentValidation;
using GuardExtensions.Primitives;

namespace PersonService.Api.Validators;

public class BasePersonValidator : AbstractValidator<BasePerson>
{
    public BasePersonValidator()
    {
        RuleFor(c => c.Name).Must(SpecialCharactersValidation);
        RuleFor(c => c.Password).Must(SpecialCharactersValidation);
    }

    private static bool SpecialCharactersValidation(string input)
    {
        return !Regex.IsMatch(input, RegexPatterns.SpecialCharactersPattern) && !string.IsNullOrEmpty(input);
    }
}