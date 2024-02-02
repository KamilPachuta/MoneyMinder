using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

public class PaymentReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }

    public Guid CurrencyAccountId { get; set; }

    public PaymentReadModel()
    {
        
    }

    public PaymentReadModel(Guid id, string name, DateTime date, Currency currency, decimal amount, Category category)
    {
        Id = id;
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
        Category = category;
    }
}
