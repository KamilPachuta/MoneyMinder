using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

public class ExpenseModel
{
    public Guid Id { get; set; }
    public Category Category { get; set; }
    public decimal Amount { get; set; }

    public Guid BudgetId { get; set; }
    
    public ExpenseModel()
    {
        
    }
    public ExpenseModel(Category category, decimal amount)
    {
        Category = category;
        Amount = amount;
    }
}