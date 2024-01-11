using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;


internal sealed class PositiveBalanceException(decimal amount) : MoneyMinderException($"Attempted to create an payment with a positive balance: '{amount}'.");
