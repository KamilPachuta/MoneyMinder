using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class CurrencyTransactionDateBeforeAccountCreationException(DateTime transactionDate, DateTime accountCreationDate) 
    : MoneyMinderException($"Transaction date {transactionDate} is before account creation date {accountCreationDate}");