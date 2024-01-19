using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public abstract record Transaction
{
    
    public TransactionName Name { get; }
    public DateTime Date { get; }
    public Currency Currency { get; }
    public Amount Amount { get; }
    

    protected Transaction(TransactionName name, DateTime date, Currency currency, Amount amount)
    {
        CheckAmount(amount);
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
    }
    protected abstract void CheckAmount(Amount amount);

    public override string ToString()
    {
        return $"TransactionName: '{Name.Name}'\nTransactionDate: '{Date}'\nCurrency: '{Currency}'\nAmount: '{Amount}'\n";
    }
    
}