using MoneyMinder.Domain.CurrencyAccounts.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Income : Transaction
{
    private Income()
    {
    }
    
    public Income(TransactionName transactionName, DateTime transactionDate, Currency currency, Amount amount) 
        : base(transactionName, transactionDate, currency, amount)
    {
        CheckAmount(amount);
    }
    
    /// <summary>
    /// Checks if the specified amount is less than or equal to zero, and throws a <see cref="NegativeBalanceException"/> if not.
    /// </summary>
    /// <param name="amount">The amount to be checked.</param>
    /// <exception cref="NegativeBalanceException">Thrown when the amount is less than or equal to zero.</exception>
    protected void CheckAmount(Amount amount)
    {
        if (amount.Value <= 0)
        {
            throw new NegativeBalanceException(amount);
        }
    }
}