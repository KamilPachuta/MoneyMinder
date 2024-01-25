using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

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