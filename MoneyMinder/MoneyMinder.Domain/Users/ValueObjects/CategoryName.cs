using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.Users.ValueObjects;

public record CategoryName
{
    public string Name { get; }

    public CategoryName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptyCategoryNameException();
        }

        if (name.Length <= 0 || name.Length > 25)
        {
            throw new InvalidLengthCategoryNameException(name);
        }
        
        Name = name;
    }
}