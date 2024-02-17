using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Accounts.Models;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.Accounts;

internal sealed class GetNotificationsHandler : IRequestHandler<GetNotifications, IEnumerable<NotificationModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetNotificationsHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<NotificationModel>> Handle(GetNotifications request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Accounts
            .Include(a => a.Notifications)
            .FirstOrDefaultAsync(a => a.Id == request.Id);

        if (result is null)
        {
            return null;
        }

        return result.Notifications.Adapt<IEnumerable<NotificationModel>>();
    }
}