using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public record MonthlyPayment : MonthlyTransaction
{
    public CategoryName CategoryName { get; set; }
    
    public MonthlyPayment(MonthlyTransactionName name, Month date, Currency currency, decimal amount, CategoryName categoryName) 
        : base(name, date, currency, amount)
    {
        CategoryName = categoryName;
    }

    protected override void CheckAmount(decimal amount)
    {
        if (amount >= 0)
        {
            throw new PositiveBalanceException(amount);
        }
    }
}