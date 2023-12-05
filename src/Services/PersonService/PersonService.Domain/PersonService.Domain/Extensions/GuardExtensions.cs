using Ardalis.GuardClauses;
using Domain.Primitives;

namespace Domain.Extensions;

public static class GuardExtensions
{
    public static void IsEmailValid(this IGuardClause guardClause, string input)
    {
        guardClause.NullOrEmpty(input, nameof(input));

        if (!input.Contains('@'))
        {
            throw new ArgumentException(DomainExceptionMessages.InvalidEmailException);
        }
    }
}