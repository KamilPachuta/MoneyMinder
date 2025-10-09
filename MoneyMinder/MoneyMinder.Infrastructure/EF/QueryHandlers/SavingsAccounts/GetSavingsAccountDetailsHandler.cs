using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.SavingsAccounts.Exceptions;
using MoneyMinder.Application.SavingsAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.SavingsAccounts;

internal class GetSavingsAccountDetailsHandler : IRequestHandler<GetSavingsAccountDetailsQuery, GetSavingsAccountDetailsResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetSavingsAccountDetailsHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetSavingsAccountDetailsResponse> Handle(GetSavingsAccountDetailsQuery request, CancellationToken cancellationToken)
    {
        var details = await _context.SavingsAccounts
            .Include(sa => sa.Transactions)
            .FirstOrDefaultAsync(sa => sa.AccountId == request.AccountId && sa.Name == request.Name, cancellationToken);

        if (details is null)
            throw new SavingsAccountNotFoundException(request.Name);
        
        return new GetSavingsAccountDetailsResponse(
            details.Id,
            details.Name,
            (CurrencyDto)details.Currency,
            details.CurrentAmount,
            details.PlannedAmount,
            details.Transactions.Select(t => new SavingsTransactionDto
            {
                Id = t.Id,
                Name = t.Name,
                Date = t.Date,
                Amount = t.Amount,
                TransactionType = (TransactionTypeDto)t.Type
            }));
    }  
}