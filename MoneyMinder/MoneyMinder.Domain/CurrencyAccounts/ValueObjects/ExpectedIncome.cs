using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record ExpectedIncome
{
    public decimal Amount { get; }

    public ExpectedIncome(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException(amount);
        }

        Amount = amount;
    }
}