using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;


internal sealed class PositiveBalanceException(Amount amount) : MoneyMinderException($"Attempted to create an payment with a positive balance: '{amount}'.");
