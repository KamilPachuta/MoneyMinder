using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.SavingsAccounts.Exceptions;

public sealed class SavingsAccountOwnershipException(Guid accountId, Guid savingsAccountId) 
    : MoneyMinderException($"The account with ID: '{accountId}' is not the owner of the savings account with ID: '{savingsAccountId}'.");