using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetCurrencyAccountsHandler : IRequestHandler<GetCurrencyAccounts, IEnumerable<Domain.CurrencyAccounts.CurrencyAccount>>
{
    private readonly DbSet<CurrencyAccount> _currencyAccounts; 

    public GetCurrencyAccountsHandler(MoneyMinderDbContext dbContext)
    {
        _currencyAccounts = dbContext.CurrencyAccounts;
    }
    
    public async Task<IEnumerable<Domain.CurrencyAccounts.CurrencyAccount>> Handle(GetCurrencyAccounts request, CancellationToken cancellationToken)
    {
        return await _currencyAccounts
            .Include(ca => ca.Budget)
            .Include(ca => ca.Balances)
            .Include(ca => ca.Incomes)
            .Include(ca => ca.Payments)
            .Include(ca => ca.MonthlyIncomes)
            .Include(ca => ca.MonthlyPayments)
            .ToListAsync();
    }
}