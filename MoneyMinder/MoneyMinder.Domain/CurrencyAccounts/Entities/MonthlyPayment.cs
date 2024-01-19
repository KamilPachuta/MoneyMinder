using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class MonthlyPayment : MonthlyTransaction
{
    public CategoryName CategoryName { get; set; }
    
    public MonthlyPayment(MonthlyTransactionName name, Month month, Currency currency, Amount amount, CategoryName categoryName) 
        : base(Guid.NewGuid(), name, month, currency, amount)
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