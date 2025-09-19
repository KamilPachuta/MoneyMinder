using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.Shared.Primitives;

public abstract class Transaction : Entity
{
    public TransactionName Name { get; }
    public TransactionDate Date { get; }
    public TransactionCurrency Currency { get; }
    public TransactionAmount Amount { get; }
    
    
    private Transaction()
    {
    }
    
    protected Transaction(TransactionName name, TransactionDate date, TransactionCurrency currency, TransactionAmount amount)
        : base(Guid.NewGuid())
    {
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
    }
}