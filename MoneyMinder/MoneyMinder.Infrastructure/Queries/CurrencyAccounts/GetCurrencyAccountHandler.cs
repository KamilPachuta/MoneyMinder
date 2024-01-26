using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetCurrencyAccountHandler : IRequestHandler<GetCurrencyAccount, Domain.CurrencyAccounts.CurrencyAccount>
{
    private readonly DbSet<CurrencyAccount> _currencyAccounts; 

    public GetCurrencyAccountHandler(MoneyMinderDbContext dbContext)
    {
        _currencyAccounts = dbContext.CurrencyAccounts;
    }
    
    public async Task<Domain.CurrencyAccounts.CurrencyAccount> Handle(GetCurrencyAccount request, CancellationToken cancellationToken)
    {
        return await _currencyAccounts.FirstOrDefaultAsync(ca => ca.Id == request.id);
    }
}