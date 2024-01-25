using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class BudgetNotFoundException : MoneyMinderException
{
    public BudgetNotFoundException()
        : base("Budget for current month not found.")
    {
    }
}