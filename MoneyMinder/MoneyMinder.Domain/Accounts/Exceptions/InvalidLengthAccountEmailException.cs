using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidLengthAccountEmailException(string email) : MoneyMinderException($"Email: '{email}' is too long.");