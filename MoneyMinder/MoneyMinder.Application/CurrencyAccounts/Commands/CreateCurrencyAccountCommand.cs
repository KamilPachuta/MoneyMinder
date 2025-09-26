using MediatR;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record CreateCurrencyAccountCommand(Guid AccountId, string Name) : IRequest;