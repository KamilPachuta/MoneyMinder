namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record Amount
{
    public decimal Value { get; init; }

    public Amount(decimal value)
    {
        Value = value;
    }
}