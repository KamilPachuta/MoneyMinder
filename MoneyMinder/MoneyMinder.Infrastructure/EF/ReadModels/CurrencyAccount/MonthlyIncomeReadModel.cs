using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

public class MonthlyIncomeReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Month { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public Guid CurrencyAccountId { get; set; }

    public MonthlyIncomeReadModel()
    {
        
    }

    public MonthlyIncomeReadModel(Guid id, string name, DateTime month, Currency currency, decimal amount)
    {
        Id = id;
        Name = name;
        Month = month;
        Currency = currency;
        Amount = amount;
    }
}
