using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

public record BudgetModel(Guid Id, string Name, Currency Currency, decimal ExpectedIncome, DateTime Date, IEnumerable<ExpenseModel> Expenses);
