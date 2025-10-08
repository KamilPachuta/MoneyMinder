using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.SavingsAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.SavingsAccounts;

internal class GetSavingsAccountsDetailsHandler
    : IRequestHandler<GetSavingsAccountsDetailsQuery, GetSavingsAccountsDetailsResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetSavingsAccountsDetailsHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetSavingsAccountsDetailsResponse> Handle(GetSavingsAccountsDetailsQuery request, CancellationToken cancellationToken)
    {
        var details = await _context.SavingsAccounts
            .Where(sa => sa.AccountId == request.AccountId)
            .Select(sa => new SavingsAccountDetailsDto
            {
                Id = sa.Id,
                Name = sa.Name,
                Currency = (CurrencyDto)sa.Currency,
                CurrentAmount = sa.CurrentAmount,
                PlannedAmount = sa.PlannedAmount
            })
            .ToListAsync(cancellationToken);
        
        return new GetSavingsAccountsDetailsResponse(details);
    }
}

