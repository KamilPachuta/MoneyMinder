using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public record Income : Transaction
{
    public Income(TransactionName transactionName, DateTime transactionDate, Currency currency, decimal amount) 
        : base(transactionName, transactionDate, currency, amount)
    {
    }

    /// <summary>
    /// Checks if the specified amount is less than or equal to zero, and throws a <see cref="NegativeBalanceException"/> if not.
    /// </summary>
    /// <param name="amount">The amount to be checked.</param>
    /// <exception cref="NegativeBalanceException">Thrown when the amount is less than or equal to zero.</exception>
    protected override void CheckAmount(decimal amount)
    {
        if (amount <= 0)
        {
            throw new NegativeBalanceException(amount);
        }
    }
}