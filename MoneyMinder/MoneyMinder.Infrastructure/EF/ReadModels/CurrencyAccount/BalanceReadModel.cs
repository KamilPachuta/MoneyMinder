using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

public class BalanceReadModel
{
    public Guid CurrencyAccountId { get; set; }

    public Guid Id { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }

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