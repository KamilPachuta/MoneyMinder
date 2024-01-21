using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Accounts.Services;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.EF.ReadServices;

internal sealed class AccountReadService : IAccountReadService
{
    private DbSet<Account> _accounts;

    public AccountReadService(MoneyMinderDbContext dbContext)
        => _accounts = dbContext.Accounts;

    public async Task<bool> CheckUnique(AccountEmail email)
        => await _accounts.AnyAsync(a => a.Email == email);
}