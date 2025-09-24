using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class PositiveAmountException(decimal amount)
    : MoneyMinderException($"Payment amount: '{amount}' cannot be positive.");
