using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.Accounts.Exceptions;

public sealed class AccountAlreadyExistException(AccountEmail email) : MoneyMinderException($"Account assigned to email: '{email}' already exist.");