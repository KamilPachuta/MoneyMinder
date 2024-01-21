using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;


internal sealed class EmptyAddressCityException : MoneyMinderException
{
    public EmptyAddressCityException()
        : base("AddressCity cannot be empty.")
    {
    }
}