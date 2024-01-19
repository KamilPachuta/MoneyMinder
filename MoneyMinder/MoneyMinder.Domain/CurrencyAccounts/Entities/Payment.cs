using MoneyMinder.Domain.CurrencyAccounts.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Payment : Transaction
{
    public CategoryName CategoryName { get; set; }
    
    public Payment(TransactionName name, DateTime date, Currency currency, Amount amount, CategoryName categoryName) : base(Guid.NewGuid(), name, date, currency, amount)
    {
        CategoryName = categoryName;
    }

    /// <summary>
    /// Checks if the specified amount is greater than or equal to zero, and throws a <see cref="PositiveBalanceException"/> if not.
    /// </summary>
    /// <param name="amount">The amount to be checked.</param>
    /// <exception cref="PositiveBalanceException">Thrown when the amount is not greater than or equal to zero.</exception>
    protected override void CheckAmount(Amount amount)
    {
        if (amount.Value >= 0)
        {
            throw new PositiveBalanceException(amount);
        }
    }
}