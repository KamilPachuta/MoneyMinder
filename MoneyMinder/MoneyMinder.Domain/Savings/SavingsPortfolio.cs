using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.Savings.DomainEvents;
using MoneyMinder.Domain.Savings.ValueObjects;

namespace MoneyMinder.Domain.Savings;

public class SavingsPortfolio : AggregateRoot
{
    public SavingsPortfolioName Name { get; set; }
    public Currency Currency { get; set; }
    public PositiveAmount PlannedAmount { get; set; }
    public PositiveAmount ActualAmount { get; set; }

    private SavingsPortfolio()
    {
    }
    
    public SavingsPortfolio(Guid id, SavingsPortfolioName name, Currency currency, PositiveAmount plannedAmount, PositiveAmount actualAmount)
        : base(id)
    {
        Name = name;
        Currency = currency;
        PlannedAmount = plannedAmount;
        ActualAmount = actualAmount;
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
    
    
}