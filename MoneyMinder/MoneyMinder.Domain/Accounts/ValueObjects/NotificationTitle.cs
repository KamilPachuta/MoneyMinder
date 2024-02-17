using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record NotificationTitle
{
    public string Title { get; set; }

    public NotificationTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new EmptyNotificationTitleException();
        }
        
        Title = title;
    }
    
    public static implicit operator string(NotificationTitle title)
        => title.Title; 

    public static implicit operator NotificationTitle(string title)
        => new(title);
}