using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AddExpenseRequest(Guid CurrencyAccountId, Category Category, decimal ExpenseAmount);