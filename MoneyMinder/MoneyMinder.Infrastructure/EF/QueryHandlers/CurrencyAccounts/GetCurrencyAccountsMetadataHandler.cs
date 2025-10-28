using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountsMetadataHandler : IRequestHandler<GetCurrencyAccountsMetadataQuery, GetCurrencyAccountsMetadataResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountsMetadataHandler(MoneyMinderReadDbContext context)
    {
            _context = context;
    }

    public async Task<GetCurrencyAccountsMetadataResponse> Handle(GetCurrencyAccountsMetadataQuery request, CancellationToken cancellationToken)
    {
        var response = await _context.CurrencyAccounts
            .Where(ca => ca.AccountId == request.AccountId)
            .Select(ca => new CurrencyAccountMetadataDto()
            {
                Id = ca.Id,
                CreatedAt = ca.CreatedAt,
                Name = ca.Name
            })
            .ToListAsync();
        
        return new GetCurrencyAccountsMetadataResponse(response);
    }
}

    
