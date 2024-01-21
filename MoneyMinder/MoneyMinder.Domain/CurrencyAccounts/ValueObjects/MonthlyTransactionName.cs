using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record MonthlyTransactionName
{
    public string Name { get; }

    public MonthlyTransactionName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptyMonthlyTransactionNameException();
        }

        if (name.Length <= 0 || name.Length > 50)
        {
            throw new InvalidLengthMonthlyTransactionNameException(name);
        }

        Name = name;
    }

    
    public static implicit operator string(MonthlyTransactionName name)
        => name.Name; 

    public static implicit operator MonthlyTransactionName(string name)
        => new(name);
    
}