using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Shared.Exceptions;

internal sealed class NegativeAmountException(decimal amount) 
    : MoneyMinderException($"Amount: '{amount}' cannot be negative.");