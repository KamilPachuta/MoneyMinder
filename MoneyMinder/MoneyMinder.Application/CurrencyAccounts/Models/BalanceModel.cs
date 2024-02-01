using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

//public record BalanceModel(Guid Id, Currency Currency, decimal Amount);
public class BalanceModel
{
    public Guid CurrencyAccountId { get; set; }

    public Guid Id { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }

    public BalanceModel()
    {
        
    }

    public BalanceModel(Guid id, Currency currency, decimal amount)
    {
        Id = id;
        Currency = currency;
        Amount = amount;
    }
}