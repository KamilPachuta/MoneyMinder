using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public abstract class MonthlyTransaction : Entity
{
    
    public MonthlyTransactionName Name { get; }
    public Month Month { get; }
    public Currency Currency { get; }
    public Amount Amount { get; }
    

    protected MonthlyTransaction(Guid id, MonthlyTransactionName name, Month month, Currency currency, Amount amount)
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