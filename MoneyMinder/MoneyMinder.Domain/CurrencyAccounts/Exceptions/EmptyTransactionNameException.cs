using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class EmptyTransactionNameException() : MoneyMinderException("Currency account name cannot be empty.");