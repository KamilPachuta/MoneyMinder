using MediatR;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record ChangeCurrecnyAccountNameCommand(Guid AccountId, Guid CurrencyAccountId, string Name) : IRequest;