using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidUserNameException(string name) : MoneyMinderException($"User name: '{name}' has incorrect format.");