using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.Accounts.Exceptions;

internal sealed class AccountNotFoundException(Guid id) : MoneyMinderException($"Account with id: '{id}' not found.");
