using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Application.SavingsAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.SavingsAccounts;

internal class GetSavingsAccountNamesHandler 
    : IRequestHandler<GetSavingsAccountNamesQuery, GetSavingsAccountNamesResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetSavingsAccountNamesHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetSavingsAccountNamesResponse> Handle(GetSavingsAccountNamesQuery request, CancellationToken cancellationToken)
    {
        var names = await _context.SavingsAccounts
            .Where(sa => sa.AccountId == request.AccountId)
            .Select(sa => sa.Name)
            .ToListAsync(cancellationToken);

        return new GetSavingsAccountNamesResponse(names);
    }
}
