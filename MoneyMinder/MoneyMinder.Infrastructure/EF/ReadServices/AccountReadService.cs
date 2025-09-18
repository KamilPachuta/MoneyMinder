using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Accounts.Services;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Shared.Repositories;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinder.Infrastructure.EF.ReadModels.Accounts;

namespace MoneyMinder.Infrastructure.EF.ReadServices;

internal sealed class AccountReadService : IAccountReadService
{
    private readonly DbSet<AccountReadModel> _accounts;

    public AccountReadService(MoneyMinderReadDbContext dbContext)
        => _accounts = dbContext.Accounts;

    public async Task<bool> CheckUnique(AccountEmail email)
        => await _accounts.AnyAsync(a => a.Email == email.Email);
  
}