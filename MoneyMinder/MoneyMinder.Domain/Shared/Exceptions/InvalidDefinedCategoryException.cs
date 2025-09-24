using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Domain.Shared.Exceptions;

internal sealed class InvalidDefinedCategoryException(Category category) 
    : MoneyMinderException($"Defined category: '{category}' is invalid.");