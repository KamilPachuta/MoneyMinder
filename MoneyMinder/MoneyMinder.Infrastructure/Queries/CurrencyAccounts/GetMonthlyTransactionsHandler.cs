using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetMonthlyTransactionsHandler : IRequestHandler<GetMonthlyTransactions, IEnumerable<MonthlyTransactionModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetMonthlyTransactionsHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<MonthlyTransactionModel>> Handle(GetMonthlyTransactions request, CancellationToken cancellationToken)
    {
        var currencyAccount = await _dbContext.CurrencyAccounts
            .Include(ca => ca.MonthlyIncomes)
            .Include(ca => ca.MonthlyPayments)
            .FirstOrDefaultAsync(ca => ca.Id == request.Id, cancellationToken);

        if (currencyAccount is null)
        {
            return null;
        }

        var result = new List<MonthlyTransactionModel>();

        var src = currencyAccount.Incomes?.First();
        var dest = src?.Adapt<TransactionModel>();
        

        var incomes = currencyAccount.MonthlyIncomes.Adapt<List<MonthlyTransactionModel>>();
        var payments = currencyAccount.MonthlyPayments.Adapt<List<MonthlyTransactionModel>>();
        if (incomes is not null)
        {
            result.AddRange(incomes);
        }

        if (payments is not null)
        {
            result.AddRange(payments);
        }

        return result.OrderByDescending(t => t.Month).ToList();
    }
}