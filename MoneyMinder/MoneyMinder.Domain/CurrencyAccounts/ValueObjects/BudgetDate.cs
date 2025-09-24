using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record BudgetDate
{
    public DateTime Date { get; }

    public BudgetDate(DateTime date)
    {
        if (date.Month != DateTime.UtcNow.Month && date.Year != DateTime.UtcNow.Year)
        {
            throw new InvalidBudgetDateException(date);
        }

        if (date.Kind != DateTimeKind.Utc)
        {
            date = date.ToUniversalTime();
        }
        
        Date = date;
    }
    
    
        
    public static implicit operator DateTime(BudgetDate date)
        => date.Date; 

    public static implicit operator BudgetDate(DateTime date)
        => new(date);
}