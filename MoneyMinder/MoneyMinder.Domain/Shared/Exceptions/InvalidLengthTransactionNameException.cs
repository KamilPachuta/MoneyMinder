using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Shared.Exceptions;

internal sealed class InvalidLengthTransactionNameException(string name)
    : MoneyMinderException($"Transaction name: '{name}' is too long.");
