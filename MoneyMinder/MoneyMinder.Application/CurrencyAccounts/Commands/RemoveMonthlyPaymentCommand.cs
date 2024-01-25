using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record RemoveMonthlyPaymentCommand(Guid AccountId, Guid CurrencyAccountId, string MonthlyPaymentName) : CurrencyCommand(AccountId, CurrencyAccountId);