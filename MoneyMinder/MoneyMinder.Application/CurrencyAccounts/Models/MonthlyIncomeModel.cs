using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

// public record MonthlyIncomeModel(Guid Id, string Name, DateTime Month, Currency Currency, decimal Amount);
public class MonthlyIncomeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Month { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public Guid CurrencyAccountId { get; set; }

    public MonthlyIncomeModel()
    {
        
    }

    public MonthlyIncomeModel(Guid id, string name, DateTime month, Currency currency, decimal amount)
    {
        Id = id;
        Name = name;
        Month = month;
        Currency = currency;
        Amount = amount;
    }
}
