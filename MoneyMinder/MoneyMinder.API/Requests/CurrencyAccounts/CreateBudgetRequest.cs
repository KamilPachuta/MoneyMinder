using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record CreateBudgetRequest(Guid CurrencyAccountId, string Name, decimal ExpectedIncome, IEnumerable<ExpenseModel> Expenses, DateTime Date, Currency Currency);