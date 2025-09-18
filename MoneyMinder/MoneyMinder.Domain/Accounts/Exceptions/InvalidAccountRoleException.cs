using MoneyMinder.Domain.Accounts.Enum;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidAccountRoleException(Role role) : MoneyMinderException($"Role: '{role}' is invalid.");