using MoneyMinder.Domain.SavingsAccounts.Enums;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.SavingsAccounts.Exceptions;

internal sealed class InvalidTransactionTypeException(TransactionType transactionType) 
    : MoneyMinderException($"Transaction type {transactionType} is invalid.");