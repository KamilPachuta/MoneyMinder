using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal sealed class GetCurrencyAccountTransactionsHandler : IRequestHandler<GetCurrencyAccountTransactionsQuery, GetCurrencyAccountTransactionsResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountTransactionsHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }
    
    public async Task<GetCurrencyAccountTransactionsResponse> Handle(GetCurrencyAccountTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _context.CurrencyAccounts
            .Where(ca => ca.Id == request.CurrencyAccountId && ca.AccountId == request.AccountId)
            .SelectMany(ca => 
                ca.Incomes.Select(i => new CurrencyTransactionDto()
                    {
                        Name = i.Name,
                        Date = i.Date,
                        Currency = (CurrencyDto)i.Currency,
                        Amount = i.Amount,
                        Category = null
                    })
                    .Concat(
                        ca.Payments.Select(p => new CurrencyTransactionDto
                        {
                            Name = p.Name,
                            Date = p.Date,
                            Currency = (CurrencyDto)p.Currency,
                            Amount = p.Amount,
                            Category = (CategoryDto)p.Category
                        })
                    )
            )
            .OrderByDescending(t => t.Date)
            .ToListAsync(cancellationToken);
        
        return new GetCurrencyAccountTransactionsResponse(transactions);
    }
}