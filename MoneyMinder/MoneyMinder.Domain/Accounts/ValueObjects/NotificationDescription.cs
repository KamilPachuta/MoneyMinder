using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record NotificationDescription
{
    public string Description { get; set; }

    public NotificationDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new EmptyNotificationDescriptionException();
        }
        
        Description = description;
    }
    
    public static implicit operator string(NotificationDescription description)
        => description.Description; 

    public static implicit operator NotificationDescription(string description)
        => new(description);
}