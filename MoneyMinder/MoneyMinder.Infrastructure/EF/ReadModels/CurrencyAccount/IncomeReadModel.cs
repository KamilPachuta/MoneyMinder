using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

public class IncomeReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }

    public Guid CurrencyAccountId { get; set; }

    public IncomeReadModel()
    {
        
    }
    public IncomeReadModel(Guid id, string name, DateTime date, Currency currency, decimal amount)
    {
        Id = id;
        Name = name;
        Currency = currency;
        Amount = amount;
        Date = Date;
    }
}