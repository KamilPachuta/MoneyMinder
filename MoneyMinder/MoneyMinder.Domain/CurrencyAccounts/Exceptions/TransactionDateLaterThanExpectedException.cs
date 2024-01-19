using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class TransactionDateLaterThanExpectedException : MoneyMinderException
{
    public Transaction Transaction { get; }

    public TransactionDateLaterThanExpectedException(Transaction transaction) 
        : base($"Transaction date is later than expected, which violates business rules.")
    {
        Transaction = transaction;
    }
}
