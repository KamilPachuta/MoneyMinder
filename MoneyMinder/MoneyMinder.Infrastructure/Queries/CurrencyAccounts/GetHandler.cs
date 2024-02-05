using System.Collections;
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
        var currencyAccount = await _dbContext.CurrencyAccounts
            .Include(ca => ca.Balances)
            .Include(ca => ca.Incomes)
            .Include(ca => ca.Payments)
            .Include(ca => ca.MonthlyIncomes)
            .Include(ca => ca.MonthlyPayments)
            .Include(ca => ca.Budget)
            .ThenInclude(b => b.Expenses)
            .FirstOrDefaultAsync(ca => ca.Id == request.Id);

        if (currencyAccount is null)
        {
            return null;
        }

        var transactions = new List<TransactionModel>();

        var incomes = currencyAccount.Incomes.Adapt<IEnumerable<TransactionModel>>();
        var payments = currencyAccount.Payments.Adapt<IEnumerable<TransactionModel>>();
        if (incomes is not null)
        {
            transactions.AddRange(incomes);
        }

        if (payments is not null)
        {
            transactions.AddRange(payments);
        }

         transactions.OrderByDescending(t => t.Date).ToList();

         var monthlyTransactions = new List<MonthlyTransactionModel>();

         var monthlyIncomes = currencyAccount.MonthlyIncomes.Adapt<IEnumerable<MonthlyTransactionModel>>();
         var monthlyPayments = currencyAccount.MonthlyPayments.Adapt<IEnumerable<MonthlyTransactionModel>>();
         if (monthlyIncomes is not null)
         {
             monthlyTransactions.AddRange(monthlyIncomes);
         }

         if (monthlyPayments is not null)
         {
             monthlyTransactions.AddRange(monthlyPayments);
         }

         monthlyTransactions.OrderByDescending(t => t.Month).ToList();

        return new CurrencyAccountModel(
            currencyAccount.Id, 
            currencyAccount.Name, 
            currencyAccount.Budget.Adapt<BudgetModel>(), 
            currencyAccount.Balances.Adapt<IEnumerable<BalanceModel>>(), 
            transactions, 
              monthlyTransactions);
        
    }

}