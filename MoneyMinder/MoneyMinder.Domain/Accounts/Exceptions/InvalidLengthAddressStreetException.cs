using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidLengthAddressStreetException(string street)
    : MoneyMinderException($"Address street: '{street}' is too long.");
