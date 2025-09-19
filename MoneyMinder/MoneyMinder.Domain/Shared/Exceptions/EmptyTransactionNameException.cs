using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.Shared.Exceptions;

internal sealed class EmptyTransactionNameException() : MoneyMinderException("Transaction name cannot be empty.");