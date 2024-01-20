using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;

internal sealed class EmptyAddressCountryException : MoneyMinderException
{
    public EmptyAddressCountryException()
        : base("AddressCountry cannot be empty.")
    {
    }
}