using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record RemoveMonthlyIncomeCommand(Guid AccountId, Guid CurrencyAccountId, string MonthlyIncomeName) : CurrencyCommand(AccountId, CurrencyAccountId);