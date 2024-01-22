using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

public class ChangeNameHandler : IRequestHandler<ChangeName>
{
    private readonly IAccountRepository _repository;

    public ChangeNameHandler(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(ChangeName request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetAsync(request.Id);

        if (account is null)
        {
            throw new AccountNotFoundException(request.Id);
        }

        var name = new UserName(request.FirstName, request.LastName);
        
        account.ChangeName(name);

        await _repository.UpdateAsync(account);
    }
}