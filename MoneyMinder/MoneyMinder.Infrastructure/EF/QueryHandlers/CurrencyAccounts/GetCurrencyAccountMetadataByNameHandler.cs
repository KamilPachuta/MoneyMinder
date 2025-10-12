using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountMetadataByNameHandler : IRequestHandler<GetCurrencyAccountMetadataByNameQuery, GetCurrencyAccountMetadataByNameResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountMetadataByNameHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }
    
    public async Task<GetCurrencyAccountMetadataByNameResponse> Handle(GetCurrencyAccountMetadataByNameQuery request, CancellationToken cancellationToken)
    {
        var response = await _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId && ca.Name == request.Name)
            .Select(ca => new GetCurrencyAccountMetadataByNameResponse(ca.Id, ca.CreatedAt))
            .FirstOrDefaultAsync(cancellationToken);
        
        if (response is null)
            throw new CurrencyAccountNotFoundException(request.Name);
        
        return response;
    }
}