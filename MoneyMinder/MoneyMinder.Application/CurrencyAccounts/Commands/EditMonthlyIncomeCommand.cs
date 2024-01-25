using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record EditMonthlyIncomeCommand(Guid AccountId, Guid CurrencyAccountId, string Name, string NewName, decimal NewAmount) : CurrencyCommand(AccountId, CurrencyAccountId);