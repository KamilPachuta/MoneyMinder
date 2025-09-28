using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccounts;

public class LimitReadModel
{
    public Guid Id { get; set; }
    public Category Category { get; set; }
    public decimal Amount { get; set; }

    public Guid BudgetId { get; set; }
    
    public LimitReadModel()
    {
    }
    
    public LimitReadModel(Category category, decimal amount)
    {
        Category = category;
        Amount = amount;
    }
}