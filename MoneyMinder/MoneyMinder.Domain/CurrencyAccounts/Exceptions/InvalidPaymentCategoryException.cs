using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Enum;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class InvalidPaymentCategoryException(Category category) 
    : MoneyMinderException($"Transaction category: '{category}' is invalid.");