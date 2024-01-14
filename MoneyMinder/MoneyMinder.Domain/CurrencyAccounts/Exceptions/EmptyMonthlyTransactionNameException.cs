using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class EmptyMonthlyTransactionNameException() : MoneyMinderException("Currency account name cannot be empty.");