using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.Shared.Primitives;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Income : Transaction
{
    private Income()
    {
    }

    public Income(TransactionName name, TransactionDate date, DefinedCurrency currency, Amount amount)
    : base(name, date, currency,amount)
    {
        CheckAmount(amount);
    }
    
    
    private void CheckAmount(decimal amount)
    {
        if (amount <= 0)
        {
            throw new NegativeAmountException(amount);
        }
    }
}