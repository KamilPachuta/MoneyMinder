using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record Month
{
    public DateTime Date { get; }

    public Month(DateTime date)
    {
        if (date.Month != DateTime.Now.Month && date.Month != DateTime.Now.AddMonths(1).Month) 
        {
            throw new InvalidMonthException(date);
        }

        if (date.Kind != DateTimeKind.Utc)
        {
            date = date.ToUniversalTime();
        }
        
        Date = date;
    }

    public Month NextMonth()
        => new(Date.AddMonths(1));

    public override string ToString()
    {
        return Date.ToString();
    }

    public static implicit operator DateTime(Month date)
        => date.Date; 

    public static implicit operator Month(DateTime date)
        => new(date);
}