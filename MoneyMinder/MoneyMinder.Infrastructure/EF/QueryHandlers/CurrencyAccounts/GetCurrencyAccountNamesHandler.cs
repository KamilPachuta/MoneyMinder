using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountNamesHandler 
    : IRequestHandler<GetCurrencyAccountNamesQuery, GetCurrencyAccountNamesResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountNamesHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetCurrencyAccountNamesResponse> Handle(GetCurrencyAccountNamesQuery request, CancellationToken cancellationToken)
    {
        var names = await _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId)
            .Select(ca => ca.Name)
            .ToListAsync(cancellationToken);

        return new GetCurrencyAccountNamesResponse(names);
    }
}
