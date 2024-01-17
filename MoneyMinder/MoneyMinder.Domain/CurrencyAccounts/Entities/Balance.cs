using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Balance : Entity
{
    public Currency Currency { get; init; }
    
    public decimal Amount { get; set; }
    
    public Balance(Guid id, Currency currency, decimal amount) : base(id)
    {
        Currency = currency;
        Amount = amount;
    }

    
    /// <summary>
    /// Changes the balance amount based on the provided transaction.
    /// </summary>
    /// <param name="transaction">The transaction to be applied to the balance.</param>
    /// <exception cref="InsufficientFundsException">Thrown when the transaction would result in a negative balance.</exception>
    public void ChangeAmount(Transaction transaction)
    {
        if (Amount + transaction.Amount < 0)
        {
            throw new InsufficientFundsException(transaction);
        }

        Amount += transaction.Amount;
    }
    
}