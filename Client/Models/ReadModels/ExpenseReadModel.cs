using Client.Models.Enums;

namespace MoneyMinderClient.Models.ReadModels;

public class ExpenseReadModel
{
    public Category Category { get; set; }
    public decimal Amount { get; set; }

    public ExpenseReadModel(Category category, decimal amount)
    {
        Category = category;
        Amount = amount;
    }
}