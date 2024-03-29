using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record BudgetName
{
    public string Name { get; }

    public BudgetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptyBudgetNameException();
        }

        if (name.Length <= 0 || name.Length > 30)
        {
            throw new InvalidLengthBudgetNameException(name);
        }

        Name = name;

    }
    
    public static implicit operator string(BudgetName name)
        => name.Name; 

    public static implicit operator BudgetName(string name)
        => new(name);
    
}



    

