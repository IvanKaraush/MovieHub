using Ardalis.GuardClauses;

namespace Domain.Entities;

public abstract class BaseEntity : IEquatable<BaseEntity>
{
    public Guid Id
    {
        get => _id;
        private init
        {
            Guard.Against.Default(value, nameof(value));
            _id = value;
        }
    }

    private readonly Guid _id;

    protected BaseEntity(Guid id)
    {
        Id = id;
    }

    public bool Equals(BaseEntity? other)
    {
        return other != null && Id == other._id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is BaseEntity entity)
        {
            return Id == entity._id;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}