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
}