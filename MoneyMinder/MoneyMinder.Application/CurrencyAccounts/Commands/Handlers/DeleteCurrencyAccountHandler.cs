using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Queries;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class DeleteCurrencyAccountHandler : CurrencyCommandHandler<DeleteCurrencyAccountCommand>
{
    public DeleteCurrencyAccountHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {

    }
    
    public override async Task Handle(DeleteCurrencyAccountCommand request, CancellationToken cancellationToken)
    {
        var currencyAccount = await GetCurremcyAccount(request.AccountId, request.CurrencyAccountId);

        await _repository.DeleteAsync(currencyAccount);
    }
}