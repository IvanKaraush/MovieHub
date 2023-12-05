using Ardalis.GuardClauses;

namespace Domain.ValueObjects;

public class ProfileCreationDate
{
    public DateOnly CreationDate { get; }

    public ProfileCreationDate(DateOnly creationDate)
    {
        Guard.Against.Default(creationDate, nameof(creationDate));
        CreationDate = creationDate;
    }
}