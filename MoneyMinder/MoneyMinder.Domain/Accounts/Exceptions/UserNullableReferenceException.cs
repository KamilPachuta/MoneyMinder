using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class UserNullableReferenceException : MoneyMinderException
{
    public UserNullableReferenceException()
        : base("Account have not assigned user.")
    {
    }
}