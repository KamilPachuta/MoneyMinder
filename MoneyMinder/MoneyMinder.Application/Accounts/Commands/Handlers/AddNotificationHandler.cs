using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

internal sealed class AddNotificationHandler : IRequestHandler<AddNotificationCommand>
{
    private readonly IAccountRepository _repository;

    public AddNotificationHandler(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(AddNotificationCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetAsync(request.Id);

        if (account is null)
        {
            throw new AccountNotFoundException(request.Id);
        }

        var notification = new Notification( request.Title, request.Description, DateTime.UtcNow);
        
        account.AddNotification(notification);
        
        await _repository.UpdateAsync(account);
    }
}