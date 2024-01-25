using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class DifferentExpenseException : MoneyMinderException
{
    public Category Category { get; }
    public Category SearchedCategory { get; }


    public DifferentExpenseException(Category category, Category searchedCategory)
        : base($"Expenes are different: '{category}', searched category: '{searchedCategory}'")
    {
        Category = category;
        SearchedCategory = searchedCategory;
    }
}