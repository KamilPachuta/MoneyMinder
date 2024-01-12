using MoneyMinder.Domain.Primitives;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Expense : Entity
{
    public CategoryName Category { get; init; }
    public decimal Amount { get; init; }

    public Expense(Guid id, CategoryName category, decimal amount) : base(id)
    {
        Category = category;
        Amount = amount;
    }
    public static bool operator ==(Expense? first, Expense? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Expense? first, Expense? second)
    {
        return !(first == second);
    }

}