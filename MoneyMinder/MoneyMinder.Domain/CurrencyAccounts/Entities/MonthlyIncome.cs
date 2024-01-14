using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public record MonthlyIncome : MonthlyTransaction
{
    public MonthlyIncome(MonthlyTransactionName monthlyTransactionName, Month monthlyTransactionDate, Currency currency, decimal amount) 
        : base(monthlyTransactionName, monthlyTransactionDate, currency, amount)
    {
    }

    protected override void CheckAmount(decimal amount)
    {
        if (amount <= 0)
        {
            throw new NegativeBalanceException(amount);
        }
    }
}