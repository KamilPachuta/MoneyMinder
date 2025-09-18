using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidLengthAddressCityException(string city)
    : MoneyMinderException($"Address city: '{city}' is too long.");
