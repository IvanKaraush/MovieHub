using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using GuardExtensions.Primitives;

namespace GuardExtensions;

public static class GuardExtension
{
    public static void SpecialCharacters(this IGuardClause guardClause, string input, string parameterName)
    {
        guardClause.NullOrEmpty(input, nameof(input));

        if (Regex.IsMatch(input, RegexPatterns.SpecialCharactersPattern))
        {
            throw new ArgumentException(GuardExtensionMessages.SpecialCharactersException, parameterName);
        }
    }

    public static void IsNullOrDefault(this IGuardClause guardClause, Guid input, string parameterName)
    {
        guardClause.Null(input, parameterName);
        guardClause.Default(input, parameterName);
    }
}