using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record ExpenseAmount
{
    public decimal Amount { get; }

    public ExpenseAmount(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException(amount);
        }

        Amount = amount;
    }
    
    
    public static implicit operator decimal(ExpenseAmount amount)
        => amount.Amount; 

    public static implicit operator ExpenseAmount(decimal amount)
        => new(amount);
}