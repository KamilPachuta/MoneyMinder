using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.Primitives;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Budget : Entity
{
    public DefinedCurrency Currency { get; init; }
    public BudgetDate Date { get; init; }

    public List<Limit> Limits { get; } = new();

    private Budget()
    {
    }
    
    public Budget(BudgetDate date, DefinedCurrency currency, List<Limit> limits)
    {
        Date = date;
        Currency = currency;

        if (limits.Count != DefinedCategory.Count())
            throw new IncorrectLimitsCount();
        
        Limits =  limits;
    }

    internal void ModifyLimit(Limit limit)
    {
        var toModify = Limits.FirstOrDefault(l => l.Equals(limit));

        if (toModify == null)
            throw new LimitNotFoundException(limit.Category); 
                
        toModify.ChangeAmount(limit.Amount);
    }

    internal bool Exist(DateTime date)
        => Date.Date.Month == date.Month && Date.Date.Year == date.Year;


}