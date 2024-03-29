using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record TransactionName
{
    public string Name { get; }

    public TransactionName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptyTransactionNameException();
        }

        if (name.Length <= 0 || name.Length > 50)
        {
            throw new InvalidLengthTransactionNameException(name);
        }

        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }

    public static implicit operator string(TransactionName name)
        => name.Name; 

    public static implicit operator TransactionName(string name)
        => new(name);
    
}