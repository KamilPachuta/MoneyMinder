using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.Accounts.Exceptions;

internal sealed class AccountNotFoundByEmailException(string email) : MoneyMinderException($"Account with email: '{email}' not found.");