using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyPasswordHashException() : MoneyMinderException("Password cannot be empty.");