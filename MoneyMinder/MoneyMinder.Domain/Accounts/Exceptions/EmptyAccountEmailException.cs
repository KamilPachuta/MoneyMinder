using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyAccountEmailException() : MoneyMinderException("Email cannot be empty.");