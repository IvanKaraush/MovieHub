using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using FilmService.Domain.Primitives;

namespace FilmService.Domain.Extensions;

public static class GuardExtensions
{
    public static void IsCorrectUrl(this IGuardClause guardClause, string input, string parameterName)
    {
        guardClause.NullOrEmpty(input, nameof(input));
        if (!Regex.IsMatch(input, RegexPatterns.IsCorrectUrlPattern))
        {
            throw new ArgumentException(ExceptionMessages.IncorrectUrlMessage);
        }
    }
}