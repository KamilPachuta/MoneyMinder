using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.SavingsAccounts.Exceptions;
using MoneyMinder.Domain.Shared.Enums;
using MoneyMinder.Domain.Shared.Exceptions;

namespace MoneyMinder.Domain.Shared.ValueObjects;

public record DefinedCategory
{
    public Category Category { get; }

    public DefinedCategory(Category category)
    {
        if (!Enum.IsDefined(typeof(Category), category))
        {
            throw new InvalidDefinedCategoryException(category);
        }

        Category = category;
    }
    
    public static int Count()
        => Enum.GetNames(typeof(Category)).Length;

    public static implicit operator Category(DefinedCategory transactionCategory)
        => transactionCategory.Category;

    public static implicit operator DefinedCategory(Category category)
        => new(category);
}