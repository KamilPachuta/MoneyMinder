using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record BudgetDate
{
    public DateTime Date { get; }

    public BudgetDate(DateTime date)
    {
        if (date.Month != DateTime.UtcNow.Month)
        {
            throw new InvalidBudgetDateException(date);
        }

        Date = date;
    }
    
    
        
    public static implicit operator DateTime(BudgetDate date)
        => date.Date; 

    public static implicit operator BudgetDate(DateTime date)
        => new(date);
}