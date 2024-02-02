using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.SavingsPortfolios.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.Savings;

public class SavingsTransactionReadModel
{ 
    public Guid Id { get; set; }
    public TransactionType Type { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }

    public Guid SavingsPortfolioId { get; set; }

    public SavingsTransactionReadModel()
    {
        
    }
    
    public SavingsTransactionReadModel(Guid id, string name, TransactionType type, DateTime date, Currency currency, decimal amount)
    {
        Id = id;
        Type = type;
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
    }
    
}
