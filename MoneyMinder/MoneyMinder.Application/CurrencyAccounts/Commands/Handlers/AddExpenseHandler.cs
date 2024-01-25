using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class AddExpenseHandler : CurrencyCommandHandler<AddExpenseCommand>
{
    public AddExpenseHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public async override Task Handle(AddExpenseCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);
       
        var expense = new Expense(request.Category, request.ExpenseAmount);
        
        currencyAccount.AddExpense(expense);

        await _repository.UpdateAsync(currencyAccount);
    }
}