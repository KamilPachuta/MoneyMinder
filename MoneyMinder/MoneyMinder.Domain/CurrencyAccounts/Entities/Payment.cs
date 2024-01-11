using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public record Payment : Transaction
{
    public CategoryName CategoryName { get; set; }
    
    public Payment(TransactionName name, DateTime date, Currency currency, decimal amount) : base(name, date, currency, amount)
    {
    }

    protected override void CheckAmount(decimal amount)
    {
        throw new NotImplementedException();
    }
}