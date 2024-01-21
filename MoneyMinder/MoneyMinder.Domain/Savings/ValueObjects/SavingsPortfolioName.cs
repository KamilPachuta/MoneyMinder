using MoneyMinder.Domain.Savings.Exceptons;

namespace MoneyMinder.Domain.Savings.ValueObjects;

public record SavingsPortfolioName
{
    public string Name { get; set; }

    public SavingsPortfolioName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptySavingsPortfolioNameException();
        }

        if (name.Length > 255)
        {
            throw new InvalidLengthSavingsPortfolioNameException(name);
        }
        
        Name = name;
    }
    
    
    public static implicit operator string(SavingsPortfolioName name)
        => name.Name; 

    public static implicit operator SavingsPortfolioName(string name)
        => new(name);
}