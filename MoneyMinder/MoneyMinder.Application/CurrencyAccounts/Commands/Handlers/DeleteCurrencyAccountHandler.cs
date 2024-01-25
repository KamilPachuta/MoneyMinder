using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class DeleteCurrencyAccountHandler : IRequestHandler<DeleteCurrencyAccountCommand>
{
    private readonly ICurrencyAccountRepository _repository;
    private readonly ICurrencyAccountReadService _readService;

    public DeleteCurrencyAccountHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }
    
    public async Task Handle(DeleteCurrencyAccountCommand request, CancellationToken cancellationToken)
    {
        if (await _readService.CheckOwner(request.AccountId, request.CurrencyAccountId))
        {
            throw new AccesDeniedException(request.AccountId, request.CurrencyAccountId);
        }

        var currencyAccount = await _repository.GetAsync(request.CurrencyAccountId);

        await _repository.DeleteAsync(currencyAccount);
    }
}