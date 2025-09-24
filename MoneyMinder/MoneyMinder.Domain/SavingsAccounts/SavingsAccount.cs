using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.SavingsAccounts.DomainEvents;
using MoneyMinder.Domain.SavingsAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Domain.SavingsAccounts;

public class SavingsAccount : AggregateRoot
{
    public SavingsAccountName Name { get; private set; }
    
    public Account Account { get; init; }


    public SavingsAccount(Guid id, Account account, SavingsAccountName name)
        : base(id)
    {
        Account = account;
        Name = name;
    }
    
    public void ChangeName(SavingsAccountName name)
    {
        var oldName = Name;

        Name = name;
        
        RaiseDomainEvent(new SavingsAccountNameChangedDomainEvent(oldName, name, this));
    }
    
    
}