using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

internal sealed class ClearNotificationsHandler : IRequestHandler<ClearNotificationsCommand>
{
    private readonly IAccountRepository _repository;

    public ClearNotificationsHandler(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(ClearNotificationsCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetAsync(request.Id);

        if (account is null)
        {
            throw new AccountNotFoundException(request.Id);
        }
        
        account.ClearNotifications();

        await _repository.UpdateAsync(account);
    }
}