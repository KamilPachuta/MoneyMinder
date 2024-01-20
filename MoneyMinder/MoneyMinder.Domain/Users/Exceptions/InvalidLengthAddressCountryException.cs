using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;


internal sealed class InvalidLengthAddressCountryException : MoneyMinderException
{
    public string Country { get; set; }

    public InvalidLengthAddressCountryException(string country)
        : base($"AddressCountry: '{country}' is too long.")
        => Country = country;
}