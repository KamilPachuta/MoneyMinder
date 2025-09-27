using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.SavingsAccounts;

public class SavingsAccountReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Currency Currency { get; set; }
    public decimal PlannedAmount { get; set; }
    public decimal CurrentAmount { get; set; }

    public Guid AccountId { get; set; }
    
    public IEnumerable<SavingsTransactionReadModel> Transactions { get; set; }

    public SavingsAccountReadModel()
    {
    }
    
    public SavingsAccountReadModel(Guid id, string name, Currency currency, decimal plannedAmount, decimal currentAmount)
    {
        Id = id;
        Name = name;
        Currency = currency;
        PlannedAmount = plannedAmount;
        CurrentAmount = currentAmount;
    }
}