using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class ExpenseAlreadyExistException : MoneyMinderException
{
    public Category Category { get; }

    public ExpenseAlreadyExistException(Category category)
        : base($"Expense with category: '{category}' already exist.")
    {
        Category = category;
    }
}