using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;


internal sealed class InvalidLengthAddressPostalCodeException : MoneyMinderException
{
    public string PostalCode { get; set; }

    public InvalidLengthAddressPostalCodeException(string postalCode)
        : base($"AddressPostalCode: '{postalCode}' is too long.")
        => PostalCode = postalCode;
}