using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccounts;

public class BudgetReadModel
{
    public Guid Id { get; set; }
    public Currency Currency { get; set; }
    public DateTime Date { get; set; }
    public Guid CurrencyAccountId { get; set; }
    
    public IEnumerable<LimitReadModel> Limits { get; set; }
    
    public BudgetReadModel()
    {
    }
    
    public BudgetReadModel(Guid id, Currency currency, DateTime date)
    {
        Id = id;
        Currency = currency;
        Date = date;
    }
}