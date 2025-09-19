using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts;

public class CurrencyAccount : AggregateRoot
{
    public CurrencyAccountName Name { get; }
    
    
    public Account Account { get; init; }

    
    private CurrencyAccount()
    {
    }

    internal CurrencyAccount(Guid id, CurrencyAccountName name, Account account)
        : base(id)
    {
        Name = name;
        Account = account;
    }
    
    
    
    
}