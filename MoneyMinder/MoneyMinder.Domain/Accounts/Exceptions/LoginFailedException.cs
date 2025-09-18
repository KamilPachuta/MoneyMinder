using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class LoginFailedException() : MoneyMinderException("Login failed.");
