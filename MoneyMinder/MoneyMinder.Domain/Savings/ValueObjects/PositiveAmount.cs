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
    
}