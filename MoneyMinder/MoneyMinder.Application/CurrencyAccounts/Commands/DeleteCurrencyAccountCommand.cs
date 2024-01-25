using MediatR;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record DeleteCurrencyAccountCommand(Guid AccountId, Guid CurrencyAccountId) : IRequest;