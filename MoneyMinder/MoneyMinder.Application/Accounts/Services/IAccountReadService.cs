using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Application.Accounts.Services;

public interface IAccountReadService
{
    Task<bool> CheckUnique(AccountEmail email);
}