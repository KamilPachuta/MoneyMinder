using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Entities;

public abstract class Transaction : Entity
{
    protected Transaction(Guid id) : base(id)
    {
    }
}