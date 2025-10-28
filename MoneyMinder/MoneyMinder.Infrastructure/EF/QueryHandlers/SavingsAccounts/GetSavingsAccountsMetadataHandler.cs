using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.SavingsAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.SavingsAccounts;

internal sealed class GetSavingsAccountsMetadataHandler : IRequestHandler<GetSavingsAccountsMetadataQuery, GetSavingsAccountsMetadataResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetSavingsAccountsMetadataHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetSavingsAccountsMetadataResponse> Handle(GetSavingsAccountsMetadataQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.SavingsAccounts
            .Where(sa => sa.AccountId == request.AccountId)
            .Select(sa => new SavingsAccountMetadataDto()
            {
                Id = sa.Id,
                Name = sa.Name,
                CreatedAt = sa.CreatedAt
            })
            .ToListAsync();
        
        return new GetSavingsAccountsMetadataResponse(result);
    }
}