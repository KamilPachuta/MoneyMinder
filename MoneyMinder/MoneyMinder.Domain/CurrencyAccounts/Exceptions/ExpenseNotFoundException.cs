using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class ExpenseNotFoundException : MoneyMinderException
{
    public Category Category { get; }

    public ExpenseNotFoundException(Category category)
        : base($"Expense with category: '{category}' not found.")
    {
        Category = category;
    }
}