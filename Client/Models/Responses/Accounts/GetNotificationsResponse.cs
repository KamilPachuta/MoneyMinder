using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses.Accounts;

public class GetNotificationsResponse : IResponse
{
    public IEnumerable<NotificationModel> Notifications { get; set; }

    public GetNotificationsResponse()
    {
        
    }
    
    public GetNotificationsResponse(IEnumerable<NotificationModel> notifications)
    {
        Notifications = notifications;
    }
}