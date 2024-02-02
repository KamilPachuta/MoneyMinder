using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Infrastructure.EF.Context;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetHandler : IRequestHandler<Get, CurrencyAccountModel>
{
    private readonly MoneyMinderReadDbContext _dbContext;


    public GetHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CurrencyAccountModel> Handle(Get request,
        CancellationToken cancellationToken)
    {
        var result = await _dbContext.CurrencyAccounts
            .Include(ca => ca.Balances)
            .Include(ca => ca.Incomes)
            .Include(ca => ca.Payments)
            .Include(ca => ca.MonthlyIncomes)
            .Include(ca => ca.MonthlyPayments)
            .Include(ca => ca.Budget)
            .FirstOrDefaultAsync(ca => ca.Id == request.Id);

        var response = result.Adapt<CurrencyAccountModel>();
        return response;
    }

}