using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Accounts.Queries;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.Accounts;


internal sealed class GetAccountsHandler : IRequestHandler<GetAccounts, IEnumerable<Account>>
{
    private readonly  DbSet<Account> _accounts;

    public GetAccountsHandler(MoneyMinderDbContext dbContext)
    {
        _accounts = dbContext.Accounts;
    }
    


    public async Task<IEnumerable<Account>> Handle(GetAccounts request, CancellationToken cancellationToken)
    {
        var result = await _accounts
            .Include(a=>a.User)
            .ThenInclude(u=> u.Address)
            .ToListAsync();

        return result;
    }
}