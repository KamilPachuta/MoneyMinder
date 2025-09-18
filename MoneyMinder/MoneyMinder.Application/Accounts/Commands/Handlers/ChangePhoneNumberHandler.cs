using MediatR;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Shared.Repositories;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

internal sealed class ChangePhoneNumberHandler : IRequestHandler<ChangePhoneNumberCommand>
{
    private readonly IAccountRepository _repository;

    public ChangePhoneNumberHandler(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(ChangePhoneNumberCommand request, CancellationToken cancellationToken)
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