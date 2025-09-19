using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Enum;

namespace MoneyMinder.Domain.Shared.Exceptions;

internal sealed class InvalidTransactionCurrencyException(Currency currency) 
    : MoneyMinderException($"Transaction currency: '{currency}' is invalid.");