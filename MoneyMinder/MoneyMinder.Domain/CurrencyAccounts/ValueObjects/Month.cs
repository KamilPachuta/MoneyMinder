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
}