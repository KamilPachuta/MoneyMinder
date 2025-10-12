namespace MoneyMinder.Domain.Shared.ValueObjects;

public record CreatedAt
{
    public DateTime Value { get; }

    public CreatedAt(DateTime createdAt)
    {
        Value = createdAt;
    }

    public static implicit operator DateTime(CreatedAt createdAt)
        => createdAt.Value;

    public static implicit operator CreatedAt(DateTime value)
        => new(value);
}