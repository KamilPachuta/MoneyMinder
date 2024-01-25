using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record AcceptMonthlyPaymentCommand(Guid AccountId, Guid CurrencyAccountId, string Name, decimal Amount) : CurrencyCommand(AccountId, CurrencyAccountId);