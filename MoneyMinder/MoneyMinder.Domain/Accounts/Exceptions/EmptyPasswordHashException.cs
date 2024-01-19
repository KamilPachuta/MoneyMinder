using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyPasswordHashException : MoneyMinderException
{
    public EmptyPasswordHashException()
        : base("")
    {
        
    }
}