using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class CreateBudgetHandler : CurrencyCommandHandler<CreateBudgetCommand>
{
    public CreateBudgetHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);

        var expenses = ToExpenses(request.Expenses);
        
        var budget = new Budget(request.Name, request.ExpectedIncome, expenses, request.Date, request.Currency);
        
        currencyAccount.CreateBudget(budget);

        await _repository.UpdateAsync(currencyAccount);
    }

    private IEnumerable<Expense> ToExpenses(IEnumerable<KeyValuePair<Category, decimal>> expenseModels)
    {
        var expenses = new List<Expense>();
        
        foreach (var expenseModel in expenseModels)
        {
            expenses.Add(new Expense(expenseModel.Key, expenseModel.Value));
        }

        return expenses;
    }
}