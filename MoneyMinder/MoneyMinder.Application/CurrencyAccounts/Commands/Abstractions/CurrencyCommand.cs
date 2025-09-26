using MediatR;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;

public abstract record CurrencyCommand(Guid AccountId, Guid CurrencyAccountId) : IRequest;