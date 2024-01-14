namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record Amount
{
    public decimal Value { get; set; }

    public Amount(decimal value)
    {
        Value = value;
    }
}