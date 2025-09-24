using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Domain.Shared.Exceptions;

internal sealed class InvalidDefinedCurrencyException(Currency currency) 
    : MoneyMinderException($"Transaction currency: '{currency}' is invalid.");