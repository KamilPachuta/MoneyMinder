using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class DuplicateLimitException(Category category) 
    : MoneyMinderException($"Limit with category: '{category}' was already defined."); 
