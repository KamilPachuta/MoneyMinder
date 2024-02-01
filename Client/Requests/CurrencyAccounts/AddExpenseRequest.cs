using Client.Models.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AddExpenseRequest(Guid Id, Category Category, decimal ExpenseAmount);