using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Enum;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class LimitNotFoundException(DefinedCategory category) 
    : MoneyMinderException($"Limit with category: '{category}' was not found.");