using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyNotificationTitleException : MoneyMinderException
{
    public EmptyNotificationTitleException()
        : base("Notification title cannot be empty.")
    {
        
    }
}