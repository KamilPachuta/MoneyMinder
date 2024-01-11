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

    public void ChangeAmount(Transaction transaction)
    {
        if (Amount + transaction.Amount < 0)
        {
            throw new InsufficientFundsException(transaction);
        }

        Amount += transaction.Amount;
    }
    
}