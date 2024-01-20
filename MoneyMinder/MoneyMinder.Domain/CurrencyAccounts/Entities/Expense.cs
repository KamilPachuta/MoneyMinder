using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Expense : Entity
{
    public CategoryName Category { get; init; }
    public ExpenseAmount Amount { get; private set; }

    public Expense(Guid id, CategoryName category, ExpenseAmount amount) 
        : base(id)
    {
        Category = category;
        Amount = amount;
    }

    internal void ChangeAmount(Expense expense)
    {
        if (expense != this)
        {
            throw new DifferentExprenseException(this, expense);
        }

        Amount = expense.Amount;
    }
    
    
    public static bool operator ==(Expense? first, Expense? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Expense? first, Expense? second)
    {
        return !(first == second);
    }

    public bool Equals(Expense? other)
    {
        if (other is null)
        {
            return false;
        }

        return other.Category == Category;
    }
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Expense entity)
        {
            return false;
        }
         
        return entity.Category == Category;
    }
}