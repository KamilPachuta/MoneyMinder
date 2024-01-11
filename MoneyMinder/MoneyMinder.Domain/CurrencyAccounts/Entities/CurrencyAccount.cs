using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public class CurrencyAccount : AggregateRoot
{
    public CurrencyAccountName Name { get; private set; }
    
    public CurrencyAccount(Guid id) : base(id)
    {
    }
}