using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record AddNotificationCommand(Guid Id, string Title, string Description) : IRequest;