using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.SavingsPortfolios.DomainEvents;
using MoneyMinder.Domain.SavingsPortfolios.Entities;
using MoneyMinder.Domain.SavingsPortfolios.ValueObjects;

namespace MoneyMinder.Domain.SavingsPortfolios;

public class SavingsPortfolio : AggregateRoot
{
    public SavingsPortfolioName Name { get; set; }
    public Currency Currency { get; set; }
    public PositiveAmount PlannedAmount { get; set; }
    public PositiveAmount ActualAmount { get; set; }
    
    public List<SavingsTransaction> Transactions { get; } = new();

    public Account Account { get; }
    

    private SavingsPortfolio()
    {
    }
    
    internal SavingsPortfolio(Guid id, SavingsPortfolioName name, Currency currency, PositiveAmount plannedAmount, PositiveAmount actualAmount, Account account)
        : base(id)
    {
        Name = name;
        Currency = currency;
        PlannedAmount = plannedAmount;
        ActualAmount = actualAmount;

        Account = account;
    }

    public void ChangeName(SavingsPortfolioName name)
    {
        var oldName = Name;
        
        Name = name;
            
        RaiseDomainEvent(new SavingsPortfolioNameChangedDomainEvent(oldName, name, this));
    }
    
    public void ChangePlannedAmount(PositiveAmount plannedAmount)
    {
        var oldAmount = PlannedAmount;

        PlannedAmount = plannedAmount;
        
        RaiseDomainEvent(new PlannedAmountChangedDomainEvent(oldAmount, plannedAmount, this));
    }


    public void ProcessTransaction(SavingsTransaction transaction)
    {
        ActualAmount = new PositiveAmount(ActualAmount.Amount + transaction.Amount.Value);
        
        Transactions.Add(transaction);
        
        RaiseDomainEvent(new SavingsTransactionProcessedDomainEvent(transaction, this));
    }
}