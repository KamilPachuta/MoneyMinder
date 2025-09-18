using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyAddressCityException() : MoneyMinderException("Address city cannot be empty.");
