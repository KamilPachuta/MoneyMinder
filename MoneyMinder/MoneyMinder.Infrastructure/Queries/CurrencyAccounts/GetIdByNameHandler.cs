using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetIdByNameHandler : IRequestHandler<GetIdByName, Guid>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetIdByNameHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(GetIdByName request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.CurrencyAccounts
            .FirstOrDefaultAsync(ca => ca.Name == request.Name && ca.AccountId == request.AccountId,
                cancellationToken: cancellationToken);

        return result.Id;
    }
}