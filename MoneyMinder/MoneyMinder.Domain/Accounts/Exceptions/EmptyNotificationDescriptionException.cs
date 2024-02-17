using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyNotificationDescriptionException : MoneyMinderException
{
    public EmptyNotificationDescriptionException()
        : base("Notification description cannot be empty.")
    {
        
    }
}