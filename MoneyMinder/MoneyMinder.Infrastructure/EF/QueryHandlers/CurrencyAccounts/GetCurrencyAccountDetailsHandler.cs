using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.CurrencyAccounts;

namespace MoneyMinder.Infrastructure.EF.QueryHandlers.CurrencyAccounts;

internal class GetCurrencyAccountDetailsHandler : IRequestHandler<GetCurrencyAccountDetailsQuery, GetCurrencyAccountDetailsResponse>
{
    private readonly MoneyMinderReadDbContext _context;

    public GetCurrencyAccountDetailsHandler(MoneyMinderReadDbContext context)
    {
        _context = context;
    }

    public async Task<GetCurrencyAccountDetailsResponse> Handle(GetCurrencyAccountDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var currencyAccount = await _context.CurrencyAccounts
            .Include(ca => ca.Balances)
            .Include(ca => ca.Incomes)
            .Include(ca => ca.Payments)
            .FirstOrDefaultAsync(ca => ca.AccountId == request.AccountId && ca.Name == request.Name, cancellationToken);

        if (currencyAccount is null)
            throw new CurrencyAccountNotFoundException(request.Name);

        var details = new GetCurrencyAccountDetailsResponse(
            currencyAccount.Id,
            currencyAccount.Name,
            currencyAccount.Balances.Select(b => new BalanceDto
            {
                Currency = (CurrencyDto)b.Currency,
                Amount = b.Amount
            }), 
            currencyAccount.Incomes.Select(i => new CurrencyTransactionDto()
            {
                Id = i.Id,
                Name = i.Name,
                Date = i.Date,
                Currency = (CurrencyDto)i.Currency,
                Amount = i.Amount,
                Category = null
            })
            .Concat(
                currencyAccount.Payments.Select(p => new CurrencyTransactionDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Date = p.Date,
                    Currency = (CurrencyDto)p.Currency,
                    Amount = p.Amount,
                    Category = (CategoryDto)p.Category
                })
            )
            .OrderByDescending(t => t.Date)
            .Take(5));
        
        return details;
    }
}