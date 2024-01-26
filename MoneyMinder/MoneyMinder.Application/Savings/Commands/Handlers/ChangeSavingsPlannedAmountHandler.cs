using MediatR;
using MoneyMinder.Application.Savings.Exceptions;
using MoneyMinder.Application.Savings.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Savings.Commands.Handlers;

internal sealed class ChangeSavingsPlannedAmountHandler : IRequestHandler<ChangeSavingsPlannedAmountCommand>
{
    private readonly ISavingsPortfolioRepository _repository;
    private readonly ISavingsPortfolioReadService _readService;

    public ChangeSavingsPlannedAmountHandler(ISavingsPortfolioRepository repository, ISavingsPortfolioReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }
    
    public async Task Handle(ChangeSavingsPlannedAmountCommand request, CancellationToken cancellationToken)
    {
        var savingsPortfolio = await _repository.GetAsync(request.SavingsPortfolioId);

        if (await _readService.CheckOwner(request.AccountId, request.SavingsPortfolioId))
        {
            throw new AccesDeniedException(request.AccountId, request.SavingsPortfolioId);
        }

        if (savingsPortfolio is null)
        {
            throw new SavingsPortfolioNotFoundException(request.SavingsPortfolioId);
        }
        
        savingsPortfolio.ChangePlannedAmount(request.PlannedAmount);

        await _repository.UpdateAsync(savingsPortfolio);
    }
    
}