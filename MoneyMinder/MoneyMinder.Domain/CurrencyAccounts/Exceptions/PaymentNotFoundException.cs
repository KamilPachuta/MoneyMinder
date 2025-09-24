using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class PaymentNotFoundException(Guid id) 
    : MoneyMinderException($"Payment with ID: '{id}' was not found.");
