using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetIdByNameHandler : IRequestHandler<GetIdByName, Guid>
{
    private readonly MoneyMinderDbContext _dbContext;

    public GetIdByNameHandler(MoneyMinderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(GetIdByName request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.CurrencyAccounts
            .FirstOrDefaultAsync(ca => ca.Name == request.Name && ca.Account.Id == request.AccountId,
                cancellationToken: cancellationToken);

        return result.Id;
    }
}