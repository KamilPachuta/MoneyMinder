using MoneyMinder.Domain.SavingsAccounts.Enums;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.SavingsAccounts;

public class SavingsTransactionReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }

    public Guid SavingsAccountId { get; set; }

    public SavingsTransactionReadModel()
    {
    }
    
    public SavingsTransactionReadModel(Guid id, string name, DateTime date, Currency currency, decimal amount, TransactionType type)
    {
        Id = id;
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
        Type = type;
        
    }
}