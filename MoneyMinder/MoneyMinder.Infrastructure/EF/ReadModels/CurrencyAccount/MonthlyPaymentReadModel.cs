using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

public class MonthlyPaymentReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Month { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }

    public Guid CurrencyAccountId { get; set; }

    
    public MonthlyPaymentReadModel()
    {
        
    }

    public MonthlyPaymentReadModel(Guid id, string name, DateTime month, Currency currency, decimal amount, Category category)
    {
        Id = id;
        Name = name;
        Month = month;
        Currency = currency;
        Amount = amount;
        Category = category;
    }
}
