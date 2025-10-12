using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.SavingsAccounts.Exceptions;

internal sealed class SavingsTransactionDateBeforeAccountCreationException(DateTime transactionDate, DateTime accountCreationDate) 
    : MoneyMinderException($"Transaction date {transactionDate} is before account creation date {accountCreationDate}");