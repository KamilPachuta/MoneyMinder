using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountBalancesHandler : IRequestHandler<GetBalancesQuery, GetCurrencyAccountBalancesResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountBalancesHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }
    
    public async Task<GetCurrencyAccountBalancesResponse> Handle(GetBalancesQuery request, CancellationToken cancellationToken)
    {
        var balances = await _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId && ca.Id == request.CurrencyAccountId)
            .SelectMany(ca => ca.Balances)
            .Select(b => new BalanceDto()
            {
                Currency = (CurrencyDto)b.Currency,
                Amount = b.Amount,
            })
            .ToListAsync(cancellationToken);
    
    
        return new GetCurrencyAccountBalancesResponse(balances);
    }
}