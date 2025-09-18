using MediatR;
using Microsoft.AspNetCore.Identity;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Shared.Repositories;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

internal sealed class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand>
{
    private readonly IAccountRepository _repository;
    private readonly IPasswordHasher<Account> _passwordHasher;

    public DeleteAccountHandler(IAccountRepository repository, IPasswordHasher<Account> passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }
    
    
    public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetAsync(request.Id);

        if (account is null)
        {
            throw new AccountNotFoundException(request.Id);
        }
        
        account.VerifyPassword(request.Password, _passwordHasher);
        
        await _repository.DeleteAsync(account);
    }
}