using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Expense : Entity
{
    public Category Category { get; init; }
    public ExpenseAmount Amount { get; private set; }

    private Expense()
    {
    }
    
    public Expense(Category category, ExpenseAmount amount) 
        : base(Guid.NewGuid())
    {
        Category = category;
        Amount = amount;
    }

    internal void ChangeAmount(Category category, ExpenseAmount amount)
    {
        if (category != Category)
        {
            throw new DifferentExpenseException(Category, category);
        }

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