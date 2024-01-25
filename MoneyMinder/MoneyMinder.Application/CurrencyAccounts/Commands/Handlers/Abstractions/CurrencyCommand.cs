using MediatR;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;

public abstract record CurrencyCommand(Guid AccountId, Guid CurrencyAccountId) : IRequest;