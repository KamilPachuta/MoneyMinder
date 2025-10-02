using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Infrastructure.Exceptions;

public sealed class UserNotLoadedException(Guid AccountId) 
    : MoneyMinderException($"User not loaded for account with ID: '{AccountId}'");