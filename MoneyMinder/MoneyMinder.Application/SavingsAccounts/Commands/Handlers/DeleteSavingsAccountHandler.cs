using MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;
using MoneyMinder.Application.SavingsAccounts.Services;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.SavingsAccounts.Commands.Handlers;

internal sealed class DeleteSavingsAccountHandler : SavingsHandler<DeleteSavingsAccountCommand>
{
    public DeleteSavingsAccountHandler(ISavingsAccountRepository repository, ISavingsAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public override async Task Handle(DeleteSavingsAccountCommand request, CancellationToken cancellationToken)
    {
        var savingsAccount = await GetSavingsAccount(request);
        
        await _repository.DeleteAsync(savingsAccount);
    }
}