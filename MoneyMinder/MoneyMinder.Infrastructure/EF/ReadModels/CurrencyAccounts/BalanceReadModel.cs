using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccounts;

public class BalanceReadModel
{
    public Guid Id { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public Guid CurrencyAccountId { get; set; }
    

    public BalanceReadModel()
    {
    }

    public BalanceReadModel(Guid id, Currency currency, decimal amount)
    {
        Id = id;
        Currency = currency;
        Amount = amount;
    }
}