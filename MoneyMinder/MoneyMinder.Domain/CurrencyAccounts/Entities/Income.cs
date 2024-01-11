using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public record Income : Transaction
{
    public Income(TransactionName transactionName, DateTime transactionDate, Currency currency, decimal amount) 
        : base(transactionName, transactionDate, currency, amount)
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