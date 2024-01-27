using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AddExpenseRequest(Guid Id, Category Category, decimal ExpenseAmount);