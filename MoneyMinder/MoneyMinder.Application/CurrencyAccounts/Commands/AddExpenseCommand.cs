using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record AddExpenseCommand(Guid AccountId, Guid CurrencyAccountId, Category Category, decimal ExpenseAmount) : CurrencyCommand(AccountId, CurrencyAccountId);
