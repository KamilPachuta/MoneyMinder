using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class InsufficientFundsToRollbackTransactionException : MoneyMinderException
{
    public Transaction Transaction { get; set; }
    
    public InsufficientFundsToRollbackTransactionException(Transaction transaction)
        : base("Insufficient funds to rollback transaction.")
    {
        Transaction = transaction;
    }
}