using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public record BudgetDate
{
    public DateTime Date { get; }

    public BudgetDate(DateTime date)
    {
        if (date.Month != DateTime.Now.Month)
        {
            throw new InvalidBudgetDateException(date);
        }

        Date = date;
    }
}