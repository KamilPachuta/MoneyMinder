using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class InsufficientFundsException(decimal amount, Currency currency)
    : MoneyMinderException($"Not enough funds to process transaction for: {amount} {currency}");
