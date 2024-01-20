using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class DifferentExprenseException : MoneyMinderException
{
    public Expense OldExpense { get; set; }
    public Expense NewExpense { get; set; }

    public DifferentExprenseException(Expense oldExpense, Expense newExpense)
        : base($"Expenses are different.\nOld expense: '{oldExpense}'\nNew expense: '{newExpense}'")
    {
        OldExpense = oldExpense;
        NewExpense = newExpense;
    }
}