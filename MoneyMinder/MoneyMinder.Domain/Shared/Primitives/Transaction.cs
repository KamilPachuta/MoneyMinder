using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.Shared.Primitives;

public abstract class Transaction : Entity
{
    public TransactionName Name { get; }
    public TransactionDate Date { get; }
    public DefinedCurrency Currency { get; }
    public Amount Amount { get; }
    
    
    protected Transaction()
    {
    }
    
    protected Transaction(TransactionName name, TransactionDate date, DefinedCurrency currency, Amount amount)
        : base(Guid.NewGuid())
    {
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
    }
}