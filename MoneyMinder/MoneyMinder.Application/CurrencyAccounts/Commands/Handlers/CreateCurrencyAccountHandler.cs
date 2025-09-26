using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Application.CurrencyAccounts.Exceptions;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class CreateCurrencyAccountHandler : IRequestHandler<CreateCurrencyAccountCommand>
{
    private readonly ICurrencyAccountFactory _factory;
    private readonly ICurrencyAccountRepository _currencyAccountRepository;
    private readonly IAccountRepository _accountRepository;


    public CreateCurrencyAccountHandler(ICurrencyAccountFactory factory, ICurrencyAccountRepository currencyAccountRepository, 
        IAccountRepository accountRepository)
    {
        _factory = factory;
        _currencyAccountRepository = currencyAccountRepository;
        _accountRepository = accountRepository;
    }
    
    public async Task Handle(CreateCurrencyAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(request.AccountId);

        if (account is null)
        {
            throw new AccountNotFoundException(request.AccountId);
        }
        
        if (account.CurrencyAccounts.Exists(ca => ca.Name == request.Name))
        {
            throw new CurrencyAccountAlreadyExistException(request.Name);
        }
        
        var currencyAccount = _factory.Create(request.Name, account);

        await _currencyAccountRepository.AddAsync(currencyAccount);
    }
}