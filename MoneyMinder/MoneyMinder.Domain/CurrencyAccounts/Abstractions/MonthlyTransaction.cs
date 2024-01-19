using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public abstract class MonthlyTransaction : Entity
{
    
    public TransactionName Name { get; set;  }
    public Month Month { get; protected set; }
    public Currency Currency { get; set; }
    public Amount Amount { get; set; }
    

    protected MonthlyTransaction(Guid id, TransactionName name, Month month, Currency currency, Amount amount)
        : base(id)
    {
        CheckAmount(amount);
        Name = name;
        Month = month;
        Currency = currency;
        Amount = amount;
    }
    protected abstract void CheckAmount(Amount amount);

    public override string ToString()
    {
        return $"TransactionName: '{Name.Name}'\nTransactionDate: '{Month}'\nCurrency: '{Currency}'\nAmount: '{Amount}'\n";
    }
    
}