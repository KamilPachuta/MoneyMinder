using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record ClearNotificationsCommand(Guid Id) : IRequest;