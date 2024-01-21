using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.Savings.ValueObjects;

public record PositiveAmount
{
    public decimal Amount { get; set; }

    public PositiveAmount(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException(amount);
        }
        
        Amount = amount;
    }
    
    
    public static implicit operator decimal(PositiveAmount amount)
        => amount.Amount; 

    public static implicit operator PositiveAmount(decimal amount)
        => new(amount);

}