using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

//public record IncomeModel(Guid Id, string Name, DateTime Date, Currency Currency, decimal Amount);
public class IncomeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }

    public Guid CurrencyAccountId { get; set; }

    public IncomeModel()
    {
        
    }
    public IncomeModel(Guid id, string name, DateTime date, Currency currency, decimal amount)
    {
        Id = id;
        Name = name;
        Currency = currency;
        Amount = amount;
        Date = Date;
    }
}