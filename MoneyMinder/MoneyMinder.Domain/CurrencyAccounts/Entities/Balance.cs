using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Balance : Entity
{
    public Currency Currency { get; init; }
    
    public Amount Amount { get; set; }

    private Balance()
    {
        
    }
    
    public Balance(Currency currency) : base(Guid.NewGuid())
    {
        Currency = currency;
        Amount = new Amount(0);
    }

    
    /// <summary>
    /// Changes the balance amount based on the provided transaction.
    /// </summary>
    /// <param name="transaction">The transaction to be applied to the balance.</param>
    /// <exception cref="InsufficientFundsException">Thrown when the transaction would result in a negative balance.</exception>
    public void ChangeAmount(Amount amount)
    {
        if (Amount.Value + amount.Value < 0)
        {
            throw new InsufficientFundsException(Currency, amount);
        }

        Amount = new( Amount.Value + amount.Value );

    }
    
}