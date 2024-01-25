using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record Month
{
    public DateTime Date { get; }

    public Month(DateTime date)
    {
        if (date.Month != DateTime.Now.Month || date.Month != DateTime.Now.AddMonths(1).Month) 
        {
            throw new InvalidMonthException(date);
        }

        Date = date;
    }

    public Month NextMonth()
        => new(Date.AddMonths(1));
    
    public static implicit operator DateTime(Month date)
        => date.Date; 

    public static implicit operator Month(DateTime date)
        => new(date);
}