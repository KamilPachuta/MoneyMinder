using MediatR;
using MoneyMinder.Application.Savings.Exceptions;
using MoneyMinder.Application.Savings.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Savings.Commands.Handlers;

internal sealed class DeleteSavingsPortfolioHandler : IRequestHandler<DeleteSavingsPortfolioCommand>
{
    private readonly ISavingsPortfolioRepository _repository;
    private readonly ISavingsPortfolioReadService _readService;

    public DeleteSavingsPortfolioHandler(ISavingsPortfolioRepository repository, ISavingsPortfolioReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }
    
    public async Task Handle(DeleteSavingsPortfolioCommand request, CancellationToken cancellationToken)
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

        await _repository.DeleteAsync(savingsPortfolio);
    }
}