using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using GuardExtensions.Primitives;

namespace GuardExtensions;

public static class GuardExtension
{
    public static void SpecialCharacters(this IGuardClause guardClause, string input)
    {
        guardClause.NullOrEmpty(input, nameof(input));

        if (Regex.IsMatch(input, RegexPatterns.SpecialCharactersPattern))
        {
            throw new ArgumentException("Invalid parameter");
        }
    }
}