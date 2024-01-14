using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record Month
{
    public DateTime Date { get; }

    public Month(DateTime date)
    {
        if (date.Month != DateTime.Now.Month || date.Month != (DateTime.Now + TimeSpan.FromDays(30)).Month) // Jak ustawic ze to ma byc kolejny miesiac?
        {
            throw new InvalidMonthException(date);
        }

        Date = date;
    }
}