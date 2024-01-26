using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Application.Savings.Exceptions;
using MoneyMinder.Application.Savings.Services;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Savings.Commands.Handlers;

internal sealed class CreateSavingsPortfolioHandler : IRequestHandler<CreateSavingsPortfolioCommand>
{
    private readonly ISavingsPortfolioRepository _savingsPortfolioRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ISavingsPortfolioFactory _factory;

    public CreateSavingsPortfolioHandler(ISavingsPortfolioRepository savingsPortfolioRepository, IAccountRepository accountRepository, ISavingsPortfolioFactory factory)
    {
        _savingsPortfolioRepository = savingsPortfolioRepository;
        _accountRepository = accountRepository;
        _factory = factory;
    }
    
    public async Task Handle(CreateSavingsPortfolioCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(request.AccountId);

        if (account is null)
        {
            throw new AccountNotFoundException(request.AccountId);
        }

        if (account.SavingsPortfolios.Exists(sp => sp.Name == request.Name))
        {
            throw new SavingsPortfolioAlreadyExistException(request.Name);
        }
        
        var savingsPortfolio = _factory.Create(request.Name, request.Currency, request.PlannedAmount, account);

        await _savingsPortfolioRepository.AddAsync(savingsPortfolio);
    }
}