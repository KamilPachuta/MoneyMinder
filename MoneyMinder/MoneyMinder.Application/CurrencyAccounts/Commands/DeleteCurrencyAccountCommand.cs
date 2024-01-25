using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record DeleteCurrencyAccountCommand(Guid AccountId, Guid CurrencyAccountId) : CurrencyCommand(AccountId, CurrencyAccountId);