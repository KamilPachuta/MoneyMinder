using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Shared.Exceptions;

internal sealed class TransactionDateInFutureException(DateTime date) 
    : MoneyMinderException($"Transaction date: '{date}' cannot be in the future."); 
