using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyAddressPostalCodeException() : MoneyMinderException("Address postal code cannot be empty.");
