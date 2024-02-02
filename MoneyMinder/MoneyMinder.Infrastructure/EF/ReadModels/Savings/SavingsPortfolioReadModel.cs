using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.Savings;

public class SavingsPortfolioReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Currency Currency { get; set; }
    public decimal PlannedAmount { get; set; }
    public decimal ActualAmount { get; set; }

    public Guid AccountId { get; set; }
    
    public IEnumerable<SavingsTransactionReadModel> Transactions { get; set; }

    public SavingsPortfolioReadModel()
    {
        
    }
    
    public SavingsPortfolioReadModel(Guid id, string name, Currency currency, decimal plannedAmount, decimal actualAmount)
    {
        Id = id;
        Name = name;
        Currency = currency;
        PlannedAmount = plannedAmount;
        ActualAmount = actualAmount;
    }

}