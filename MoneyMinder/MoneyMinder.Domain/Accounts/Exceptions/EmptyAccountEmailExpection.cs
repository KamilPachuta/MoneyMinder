using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyAccountEmailExpection() : MoneyMinderException("Account email cannot be empty.");