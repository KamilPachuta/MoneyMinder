using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.Exceptions;
using MoneyMinder.Domain.Shared.Primitives;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Limit : Entity
{
    public DefinedCategory Category { get; }
    public Amount Amount { get; private set; }

    private Limit()
    {
    }
    
    public Limit(DefinedCategory category, Amount amount) 
    {
        if (amount.Value < 0)
        {
            throw new NegativeAmountException(amount);
        }
        
        Category = category;
        Amount = amount;
    }

    public void ChangeAmount(Amount amount)
    {
        Amount = amount;
    }
    
    public bool Equals(Limit other)
    {
        return Category == other.Category;
    }
}