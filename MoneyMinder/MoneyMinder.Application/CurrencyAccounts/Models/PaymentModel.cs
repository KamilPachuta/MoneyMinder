using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

// public record PaymentModel(Guid Id, string Name, DateTime Date, Currency Currency, decimal Amount, Category Category);
public class PaymentModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }

    public Guid CurrencyAccountId { get; set; }

    public PaymentModel()
    {
        
    }

    public PaymentModel(Guid id, string name, DateTime date, Currency currency, decimal amount, Category category)
    {
        Id = id;
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
        Category = category;
    }
}
