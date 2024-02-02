using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

public class ExpenseReadModel
{
    public Guid Id { get; set; }
    public Category Category { get; set; }
    public decimal Amount { get; set; }

    public Guid BudgetId { get; set; }
    
    public ExpenseReadModel()
    {
        
    }
    public ExpenseReadModel(Category category, decimal amount)
    {
        Category = category;
        Amount = amount;
    }
}