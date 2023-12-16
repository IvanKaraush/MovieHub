using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using GuardExtensions.Primitives;

namespace GuardExtensions;

public static class GuardExtension
{
    private const int Minlength = 8;

    public static void SpecialCharacters(this IGuardClause guardClause, string input, string parameterName)
    {
        guardClause.NullOrEmpty(input, nameof(input));

        if (Regex.IsMatch(input, RegexPatterns.SpecialCharactersPattern))
        {
            throw new ArgumentException(GuardExtensionMessages.SpecialCharactersException, parameterName);
        }
    }
}