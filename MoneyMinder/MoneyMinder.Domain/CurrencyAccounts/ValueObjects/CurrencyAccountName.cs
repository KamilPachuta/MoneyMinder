using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record CurrencyAccountName
{
    public string Name { get; }

    public CurrencyAccountName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptyCurrencyAccountNameException();
        }

        if (name.Length <= 0 || name.Length > 50)
        {
            throw new InvalidLengthCurrencyAccountNameException(name);
        }

        Name = name;

    }
    
}