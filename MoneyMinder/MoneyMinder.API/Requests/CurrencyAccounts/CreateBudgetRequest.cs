using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record CreateBudgetRequest(Guid Id, string Name, decimal ExpectedIncome, IEnumerable<KeyValuePair<Category, decimal>> Expenses, DateTime Date, Currency Currency);