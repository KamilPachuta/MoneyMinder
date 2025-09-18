using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidLengthAddressCountryException(string country)
    : MoneyMinderException($"Address country: '{country}' is too long.");
