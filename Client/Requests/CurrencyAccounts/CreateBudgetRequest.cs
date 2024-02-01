using Client.Models.Enums;
using MoneyMinderClient.Models.ReadModels;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record CreateBudgetRequest(Guid Id, string Name, decimal ExpectedIncome, IEnumerable<ExpenseReadModel> Expenses, DateTime Date, Currency Currency);