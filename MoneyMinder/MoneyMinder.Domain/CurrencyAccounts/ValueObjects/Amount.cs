namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record Amount
{
    public decimal Value { get; init; }

    public Amount(decimal value)
    {
        Value = value;
    }
    
        
    public static implicit operator decimal(Amount value)
        => value.Value; 

    public static implicit operator Amount(decimal value)
        => new(value);
    
}




