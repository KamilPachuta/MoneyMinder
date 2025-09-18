using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyAddressCountryException() : MoneyMinderException("Address country cannot be empty.");
