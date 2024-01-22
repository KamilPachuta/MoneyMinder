using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

public class ChangeAddressHandler : IRequestHandler<ChangeAddress>
{
    private readonly IAccountRepository _repository;

    public ChangeAddressHandler(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task Handle(ChangeAddress request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetAsync(request.Id);

        if (account is null)
        {
            throw new AccountNotFoundException(request.Id);
        }

        var id = Guid.NewGuid();
        
        var address = new Address(id, request.Country,request.City, request.PostalCode, request.Street);
        
        account.ChangeAddress(address);

        await _repository.UpdateAsync(account);
    }
}
