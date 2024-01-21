using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyUserPhoneNumberException : MoneyMinderException
{
    public EmptyUserPhoneNumberException()
        : base($"UserPhoneNumber cannot be empty.")
    {
    }
}