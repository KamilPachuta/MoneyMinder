using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Savings.Enums;

namespace MoneyMinder.Domain.Savings.Exceptons;

internal sealed class TransactionTypeException : MoneyMinderException
{
    public TransactionType Type { get; set; }

    public TransactionTypeException(TransactionType type)
        : base($"Type: '{type}' is incorrect")
        => Type = type;
}