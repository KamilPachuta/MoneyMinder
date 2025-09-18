using MoneyMinder.Domain.Accounts.Enum;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidUserGenderException(Gender gender) : MoneyMinderException($"Gender: '{gender}' is invalid.");