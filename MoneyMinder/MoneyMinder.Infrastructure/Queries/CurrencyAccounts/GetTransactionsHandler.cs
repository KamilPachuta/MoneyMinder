using System.Collections;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Infrastructure.EF.Context;

namespace MoneyMinder.Infrastructure.Queries.CurrencyAccounts;

internal sealed class GetTransactionsHandler : IRequestHandler<GetTransactions, IEnumerable<TransactionModel>>
{
    private readonly MoneyMinderReadDbContext _dbContext;

    public GetTransactionsHandler(MoneyMinderReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<TransactionModel>> Handle(GetTransactions request, CancellationToken cancellationToken)
    {
        var currencyAccount = await _dbContext.CurrencyAccounts
            .Include(ca => ca.Incomes)
            .Include(ca => ca.Payments)
            .FirstOrDefaultAsync(ca => ca.Id == request.Id, cancellationToken);

        if (currencyAccount is null)
        {
            return null;
        }

        var result = new List<TransactionModel>();

        var incomes = currencyAccount.Incomes.Adapt<IEnumerable<TransactionModel>>();
        var payments = currencyAccount.Payments.Adapt<IEnumerable<TransactionModel>>();
        
        
        if (incomes is not null)
        {
            result.AddRange(incomes);
        }

        if (payments is not null)
        {
            result.AddRange(payments);
        }

        return result.OrderByDescending(t => t.Date).ToList();
    }
}