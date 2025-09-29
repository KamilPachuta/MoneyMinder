using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Domain.SavingsAccounts.Exceptions;

internal sealed class CurrencyMismatchException(Currency SavingsAccountCurrency, Currency TransactionCurrency) 
    : MoneyMinderException($"Currency mismatch: Savings account currency is {SavingsAccountCurrency}, but transaction currency is {TransactionCurrency}");