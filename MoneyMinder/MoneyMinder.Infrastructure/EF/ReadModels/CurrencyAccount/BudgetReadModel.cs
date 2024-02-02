using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

public class BudgetReadModel
{
    public Guid CurrencyAccountId { get; set; }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Currency Currency { get; set; }
    public decimal ExpectedIncome { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<ExpenseReadModel> Expenses { get; set; }

    public BudgetReadModel()
    {
        
    }

    public BudgetReadModel(Guid id, string name, Currency currency, decimal expectedIncome, DateTime date, IEnumerable<ExpenseReadModel> expenses)
    {
        Id = id;
        Name = name;
        Currency = currency;
        ExpectedIncome = expectedIncome;
        Date = date;
        Expenses = expenses;
    }
}
