using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

// public record MonthlyPaymentModel(Guid Id, string Name, DateTime Month, Currency Currency, decimal Amount, Category Category);
public class MonthlyPaymentModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Month { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }

    public Guid CurrencyAccountId { get; set; }

    
    public MonthlyPaymentModel()
    {
        
    }

    public MonthlyPaymentModel(Guid id, string name, DateTime month, Currency currency, decimal amount, Category category)
    {
        Id = id;
        Name = name;
        Month = month;
        Currency = currency;
        Amount = amount;
        Category = category;
    }
}
