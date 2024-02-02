using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;


public record ExpenseModel(Guid Id, Category Category, decimal Amount, Guid BudgetId);
