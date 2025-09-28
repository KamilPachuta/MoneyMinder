using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.SavingsAccounts.DomainEvents;
using MoneyMinder.Domain.SavingsAccounts.Entities;
using MoneyMinder.Domain.SavingsAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.Exceptions;
using MoneyMinder.Domain.Shared.Primitives;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.SavingsAccounts;

public class SavingsAccount : AggregateRoot
{
    public SavingsAccountName Name { get; private set; }
    public DefinedCurrency Currency { get; }
    public Amount PlannedAmount { get; private set; }
    public Amount CurrentAmount { get; private set; }
    
    public Account Account { get; init; }

    public List<SavingsTransaction> Transactions { get; } = new();
    

    private SavingsAccount()
    {
        
    }
    
    internal SavingsAccount(Guid id, SavingsAccountName name, DefinedCurrency currency, Amount plannedAmount, Account account)
        : base(id)
    {
        Account = account;
        Name = name;
        Currency = currency;
        PlannedAmount = plannedAmount;
        CurrentAmount = 0;

        RaiseDomainEvent(new SavingsAccountCreatedDomainEvent(DateTime.UtcNow, this));
    }
    
    public void ChangeName(SavingsAccountName name)
    {
        var oldName = Name;

        Name = name;
        
        RaiseDomainEvent(new SavingsAccountNameChangedDomainEvent(oldName, name, this));
    }
    
    public void ChangePlannedAmount(Amount plannedAmount)
    {
        if (plannedAmount <= 0)
            throw new NegativeAmountException(plannedAmount);
        
        var oldAmount = PlannedAmount;

        PlannedAmount = plannedAmount;
        
        RaiseDomainEvent(new PlannedAmountChangedDomainEvent(oldAmount, plannedAmount, this));
    }


    public void ProcessTransaction(SavingsTransaction transaction)
    {
        CurrentAmount = new Amount(CurrentAmount.Value + transaction.Amount.Value);
        
        Transactions.Add(transaction);
        
        RaiseDomainEvent(new SavingsTransactionProcessedDomainEvent(transaction, this));
    }
    
}