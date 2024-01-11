using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class NegativeBalanceException(decimal amount) : MoneyMinderException($"Attempted to create an income with a negative balance: '{amount}'.");
