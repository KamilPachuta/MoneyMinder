using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class NegativeBalanceException(Amount amount) : MoneyMinderException($"Attempted to create an income with a negative balance: '{amount}'.");
