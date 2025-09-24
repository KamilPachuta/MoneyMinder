using MoneyMinder.Domain.SavingsAccounts.Enums;
using MoneyMinder.Domain.SavingsAccounts.Exceptions;

namespace MoneyMinder.Domain.SavingsAccounts.ValueObjects;

public record DefinedTransactionType
{
    public TransactionType TransactionType { get; }

    public DefinedTransactionType(TransactionType transactionType)
    {
        if (!Enum.IsDefined(typeof(TransactionType), transactionType))
        {
            throw new InvalidTransactionTypeException(transactionType);
        }
        
        TransactionType = transactionType;
    }

    public static implicit operator TransactionType(DefinedTransactionType transactionType)
        => transactionType.TransactionType;

    public static implicit operator DefinedTransactionType(TransactionType transactionType)
        => new(transactionType);
}