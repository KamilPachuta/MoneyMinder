namespace MoneyMinder.Domain.Shared.ValueObjects;

public record Amount
{
    public decimal Value { get; }

    public Amount(decimal amount)
    {
        Value = amount;
    }
    
        
    public static implicit operator decimal(Amount amount)
        => amount.Value; 

    public static implicit operator Amount(decimal amount)
        => new(amount);
}