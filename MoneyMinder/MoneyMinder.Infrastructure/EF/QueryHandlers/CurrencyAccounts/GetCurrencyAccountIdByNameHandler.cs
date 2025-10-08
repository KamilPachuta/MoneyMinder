using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountIdByNameHandler : IRequestHandler<GetCurrencyAccountIdByNameQuery, GetCurrencyAccountIdByNameResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountIdByNameHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }
    
    public async Task<GetCurrencyAccountIdByNameResponse> Handle(GetCurrencyAccountIdByNameQuery request, CancellationToken cancellationToken)
    {
        var id = await _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId && ca.Name == request.Name)
            .Select(ca => ca.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (id == Guid.Empty)
            throw new CurrencyAccountNotFoundException(request.Name);
        
        return new GetCurrencyAccountIdByNameResponse(id);
    }
}