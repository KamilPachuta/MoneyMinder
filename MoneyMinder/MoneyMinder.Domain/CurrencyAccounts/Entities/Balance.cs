using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.Shared.Primitives;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Balance : Entity
{
    public DefinedCurrency Currency { get; }
    public Amount Amount { get; private set; }
    
    private Balance()
    {
    }
    
    public Balance(DefinedCurrency currency)
    {
        Currency = currency;
        Amount = new Amount(0);
    }
    
    public void ChangeAmount(Amount amount)
    {
        if (Amount.Value + amount.Value < 0)
        {
            throw new InsufficientFundsException(amount, Currency);
        }

        Amount = new( Amount.Value + amount.Value );

    }
}