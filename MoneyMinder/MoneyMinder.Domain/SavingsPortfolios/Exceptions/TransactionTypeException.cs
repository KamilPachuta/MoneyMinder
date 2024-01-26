using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.SavingsPortfolios.Enums;

namespace MoneyMinder.Domain.SavingsPortfolios.Exceptions;

internal sealed class TransactionTypeException : MoneyMinderException
{
    public TransactionType Type { get; set; }

    public TransactionTypeException(TransactionType type)
        : base($"Type: '{type}' is incorrect")
        => Type = type;
}