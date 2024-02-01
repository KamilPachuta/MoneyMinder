using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record AcceptMonthlyPaymentCommand(Guid AccountId, Guid CurrencyAccountId, string Name, decimal Amount, Currency Currency) : CurrencyCommand(AccountId, CurrencyAccountId);