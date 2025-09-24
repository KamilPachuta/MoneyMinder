using MoneyMinder.Domain.Accounts.Enums;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidUserGenderException(Gender gender) : MoneyMinderException($"Gender: '{gender}' is invalid.");