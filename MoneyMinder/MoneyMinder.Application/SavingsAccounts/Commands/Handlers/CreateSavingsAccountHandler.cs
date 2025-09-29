using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Application.SavingsAccounts.Exceptions;
using MoneyMinder.Application.SavingsAccounts.Services;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.SavingsAccounts.Commands.Handlers;

internal sealed class CreateSavingsAccountHandler : IRequestHandler<CreateSavingsAccountCommand>
{
    private readonly ISavingsAccountFactory _factory;
    private readonly ISavingsAccountRepository _repository;
    private readonly IAccountRepository _accountRepository;
    private readonly ISavingsAccountReadService _savingsAccountReadService;
    
    public CreateSavingsAccountHandler(
        ISavingsAccountFactory factory, 
        ISavingsAccountRepository repository, 
        IAccountRepository accountRepository, 
        ISavingsAccountReadService savingsAccountReadService)
    {
        _factory = factory;
        _repository = repository;
        _accountRepository = accountRepository;
        _savingsAccountReadService = savingsAccountReadService;
    }
    
    public async Task Handle(CreateSavingsAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(request.AccountId);
        
        if (account is null)
        {
            throw new AccountNotFoundException(request.AccountId);
        }
        
        if (!await _savingsAccountReadService.CheckUnique(request.AccountId, request.Name))
        {
            throw new SavingsAccountAlreadyExistException(request.Name);
        }

        var savingsAccount = _factory.Create(request.Name, request.Currency, request.PlannedAmount, account);
        
        await _repository.AddAsync(savingsAccount);
    }
}