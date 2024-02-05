using Client.Models.Enums;

namespace Client.Models.ReadModels;

public class ExpenseModel
{
    public Category Category { get; set; }
    public decimal Amount { get; set; }

    public ExpenseModel(Category category, decimal amount)
    {
        Category = category;
        Amount = amount;
    }
}