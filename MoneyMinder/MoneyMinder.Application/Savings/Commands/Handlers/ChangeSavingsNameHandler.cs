using MediatR;
using MoneyMinder.Application.Savings.Exceptions;
using MoneyMinder.Application.Savings.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Savings.Commands.Handlers;

internal sealed class ChangeSavingsNameHandler : IRequestHandler<ChangeSavingsNameCommand>
{
    private readonly ISavingsPortfolioRepository _repository;
    private readonly ISavingsPortfolioReadService _readService;

    public ChangeSavingsNameHandler(ISavingsPortfolioRepository repository, ISavingsPortfolioReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }
    
    public async Task Handle(ChangeSavingsNameCommand request, CancellationToken cancellationToken)
    {
        var savingsPortfolio = await _repository.GetAsync(request.SavingsPortfolioId);
        
        if (savingsPortfolio is null)
        {
            throw new SavingsPortfolioNotFoundException(request.SavingsPortfolioId);
        }
        
        if (await _readService.CheckOwner(request.AccountId, request.SavingsPortfolioId))
        {
            throw new AccesDeniedException(request.AccountId, request.SavingsPortfolioId);
        }

        if (await _readService.CheckUnique(request.AccountId, request.Name)) 
        {
            throw new SavingsPortfolioAlreadyExistException(request.Name);
        }
        
        savingsPortfolio.ChangeName(request.Name);

        await _repository.UpdateAsync(savingsPortfolio);
    }
}