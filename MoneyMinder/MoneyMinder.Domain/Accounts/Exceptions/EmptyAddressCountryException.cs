using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyAddressCountryException : MoneyMinderException
{
    public EmptyAddressCountryException()
        : base("AddressCountry cannot be empty.")
    {
    }
}