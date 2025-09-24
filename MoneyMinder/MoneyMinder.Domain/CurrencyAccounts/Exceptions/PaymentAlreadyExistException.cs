using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class PaymentAlreadyExistException(Payment payment) : MoneyMinderException($"Payment: '{payment}' already exist.");
