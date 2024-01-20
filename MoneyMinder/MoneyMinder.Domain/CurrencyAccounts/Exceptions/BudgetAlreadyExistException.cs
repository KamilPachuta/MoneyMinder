using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class BudgetAlreadyExistException : MoneyMinderException
{
    public DateTime Month { get; set; }
    
    
    public BudgetAlreadyExistException(DateTime month)
        : base($"Budged for current month '{month.Month.ToString()}'")
    {
        Month = month;
    }
}