using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidLengthAddressPostalCodeException(string postalCode) : MoneyMinderException($"Address postal code: '{postalCode}' is too long.");