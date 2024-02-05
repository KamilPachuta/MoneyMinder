using Client.Models.Enums;

namespace Client.Models.WriteModels;

public class ExpenseWriteModel
{
    public Category Category { get; set; }
    public decimal Amount { get; set; }

    public ExpenseWriteModel()
    {
        
    }
    
    public ExpenseWriteModel(Category category, decimal amount)
    {
        Category = category;
        Amount = amount;
    }
    
}