using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

public class ChangePhoneNumberHandler : IRequestHandler<ChangePhoneNumber>
{
    private readonly IAccountRepository _repository;

    public ChangePhoneNumberHandler(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(ChangePhoneNumber request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetAsync(request.Id);

        if (account is null)
        {
            throw new AccountNotFoundException(request.Id);
        }

        var phoneNumber = new UserPhoneNumber(request.Code, request.Number);
        
        account.ChangePhoneNumber(phoneNumber);

        await _repository.UpdateAsync(account);
    }
}