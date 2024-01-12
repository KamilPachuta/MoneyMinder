using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class Budget : Entity
{
    public BudgetName Name { get; init; }
    public decimal ExpectedIncome { get; init; }
    public BudgetDate Date { get; init; }
    
    public IEnumerable<Expense> Expenses => _expenses;
    
    private readonly List<Expense> _expenses = new();
    
    public Budget(Guid id, BudgetName name, decimal expectedIncome, IEnumerable<Expense> expenses, BudgetDate date) : base(id)
    {
        Name = name;
        ExpectedIncome = expectedIncome;
        Date = date;

        CheckUnique(expenses);
    }

    private void CheckUnique(IEnumerable<Expense> expenses)
    {
        foreach (var expense in expenses)
        {
            if (_expenses.All(e => e != expense))
            {
                _expenses.Add(expense);
            }
        }

        if (_expenses.Count != expenses.Count())
        {
            throw new DuplicateExpensesException(expenses);
        }
    }
}