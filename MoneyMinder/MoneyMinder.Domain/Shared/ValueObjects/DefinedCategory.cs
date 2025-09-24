using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Domain.Shared.ValueObjects;

public record DefinedCategory
{
    public Category Category { get; }

    public DefinedCategory(Category category)
    {
        if (!Enum.IsDefined(typeof(Category), category))
        {
            throw new InvalidPaymentCategoryException(category);
        }

        Category = category;
    }
    
    internal static int Count()
        => Enum.GetNames(typeof(Category)).Length;

    public static implicit operator Category(DefinedCategory transactionCategory)
        => transactionCategory.Category;

    public static implicit operator DefinedCategory(Category category)
        => new(category);
}