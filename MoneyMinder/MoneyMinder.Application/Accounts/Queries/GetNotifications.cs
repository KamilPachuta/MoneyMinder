using MediatR;
using MoneyMinder.Application.Accounts.Models;

namespace MoneyMinder.Application.Accounts.Queries;

public record GetNotifications(Guid Id) : IRequest<IEnumerable<NotificationModel>>;