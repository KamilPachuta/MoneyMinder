using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

//public record BudgetModel(Guid Id, string Name, Currency Currency, decimal ExpectedIncome, DateTime Date, IEnumerable<ExpenseModel> Expenses);
public class BudgetModel
{
    public Guid CurrencyAccountId { get; set; }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Currency Currency { get; set; }
    public decimal ExpectedIncome { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<ExpenseModel> Expenses { get; set; }

    public BudgetModel()
    {
        
    }

    public BudgetModel(Guid id, string name, Currency currency, decimal expectedIncome, DateTime date, IEnumerable<ExpenseModel> expenses)
    {
        Id = id;
        Name = name;
        Currency = currency;
        ExpectedIncome = expectedIncome;
        Date = date;
        Expenses = expenses;
    }
}
