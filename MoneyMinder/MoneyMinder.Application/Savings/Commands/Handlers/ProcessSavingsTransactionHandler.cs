using MediatR;
using MoneyMinder.Application.Savings.Exceptions;
using MoneyMinder.Application.Savings.Services;
using MoneyMinder.Domain.Repository;
using MoneyMinder.Domain.SavingsPortfolios.Entities;

namespace MoneyMinder.Application.Savings.Commands.Handlers;

internal sealed class ProcessSavingsTransactionHandler : IRequestHandler<ProcessSavingsTransactionCommand>
{
    private readonly ISavingsPortfolioRepository _repository;
    private readonly ISavingsPortfolioReadService _readService;

    public ProcessSavingsTransactionHandler(ISavingsPortfolioRepository repository,
        ISavingsPortfolioReadService readService)
    {
        _repository = repository;
        _readService = readService;
    }

    public async Task Handle(ProcessSavingsTransactionCommand request, CancellationToken cancellationToken)
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

        var transaction =
            new SavingsTransaction(request.Name, request.Date, savingsPortfolio.Currency, request.Amount, request.Type);
        
        savingsPortfolio.ProcessTransaction(transaction);

        await _repository.UpdateAsync(savingsPortfolio);
    }
}