using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

public class CreateCurrencyAccountHandler : IRequestHandler<CreateCurrencyAccount>
{
    private readonly ICurrencyAccountFactory _factory;
    private readonly ICurrencyAccountRepository _repository;
    private readonly ICurrencyAccountReadService _readService;

    public CreateCurrencyAccountHandler(ICurrencyAccountFactory factory, ICurrencyAccountRepository repository, ICurrencyAccountReadService readService)
    {
        _factory = factory;
        _repository = repository;
        _readService = readService;
    }
    
    public async Task Handle(CreateCurrencyAccount request, CancellationToken cancellationToken)
    {
        if (_readService.CheckUnique(request.Name))
        {
            throw new CurrencyAccountAlreadyExistException(request.Name);
        }
        
        var currencyAccount = _factory.Create(request.Name);

        await _repository.AddAsync(currencyAccount);
    }
}