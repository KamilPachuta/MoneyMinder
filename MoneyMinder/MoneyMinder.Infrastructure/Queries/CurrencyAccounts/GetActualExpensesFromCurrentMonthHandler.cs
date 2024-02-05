using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetActualExpensesFromCurrentMonthHandler : IRequestHandler<GetActualExpensesFromCurrentMonth, IEnumerable<PaymentModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetActualExpensesFromCurrentMonthHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<PaymentModel>> Handle(GetActualExpensesFromCurrentMonth request, CancellationToken cancellationToken)
    {
        var currencyAccount = await _dbContext.CurrencyAccounts
            .Include(ca => ca.Payments)
            .FirstOrDefaultAsync(ca => ca.Id == request.Id);

        if (currencyAccount is null)
        {
            return null;
        }

        var date = DateTime.UtcNow;
        var result = currencyAccount.Payments.Where(p => (p.Date.Month == date.Month && p.Date.Year == date.Year));

        return result.Adapt<IEnumerable<PaymentModel>>();
    }
}