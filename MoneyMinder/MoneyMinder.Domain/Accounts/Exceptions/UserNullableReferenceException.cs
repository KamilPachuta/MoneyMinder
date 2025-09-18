using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class UserNullableReferenceException() : MoneyMinderException("Account has no User assigned.");