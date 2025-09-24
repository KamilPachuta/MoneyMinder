using MoneyMinder.Domain.Accounts.Enums;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidAccountRoleException(Role role) : MoneyMinderException($"Role: '{role}' is invalid.");