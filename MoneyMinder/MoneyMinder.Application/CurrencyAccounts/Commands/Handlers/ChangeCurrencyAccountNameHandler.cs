using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class ChangeCurrencyAccountNameHandler : IRequestHandler<ChangeCurrecnyAccountNameCommand>
{
    private readonly ICurrencyAccountRepository _repository;
    private readonly ICurrencyAccountReadService _readService;

    public ChangeCurrencyAccountNameHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }
    
    public async Task Handle(ChangeCurrecnyAccountNameCommand request, CancellationToken cancellationToken)
    {
        if (await _readService.CheckOwner(request.AccountId, request.CurrencyAccountId))
        {
            throw new AccesDeniedException(request.AccountId, request.CurrencyAccountId);
        }

        if (await _readService.CheckUnique(request.AccountId,request.Name))
        {
            throw new CurrencyAccountAlreadyExistException(request.Name);
        }
        
        var currencyAccount = await _repository.GetAsync(request.CurrencyAccountId);

        if (currencyAccount is null)
        {
            throw new CurrencyAccountNotFoundException(request.CurrencyAccountId);
        }
        
        currencyAccount.ChangeName(request.Name);

        await _repository.UpdateAsync(currencyAccount);
    }
}