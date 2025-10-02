using MoneyMinder.Domain.SavingsAccounts.Exceptions;

namespace MoneyMinder.Domain.SavingsAccounts.ValueObjects;

public record SavingsAccountName
{
    public string Name { get; }
    
    public SavingsAccountName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptySavingsAccountNameException();
        }

        if (name.Length > 50 || name.Length < 3)
        {
            throw new InvalidLengthSavingsAccountNameException(name);
        }
        
        Name = name;
    }
    
    public static implicit operator string(SavingsAccountName name)
        => name.Name; 
    
    public static implicit operator SavingsAccountName(string name)
        => new(name);
}