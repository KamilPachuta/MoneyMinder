using Client.Models.Enums;

namespace Client.Models.ReadModels;

public record BudgetModel(Guid Id, string Name, Currency Currency, decimal ExpectedIncome, DateTime Date, IEnumerable<ExpenseModel> Expenses);
