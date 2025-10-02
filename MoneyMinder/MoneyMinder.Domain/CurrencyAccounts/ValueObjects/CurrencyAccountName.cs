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
        
        if (name.Length > 50 || name.Length < 3)
        {
            throw new InvalidLengthCurrencyAccountNameException(name);
        }
        
        Name = name;
    }
    
    public static implicit operator string(CurrencyAccountName name)
        => name.Name; 
    
    public static implicit operator CurrencyAccountName(string name)
        => new(name);
}