using MediatR;
using Microsoft.AspNetCore.Identity;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

internal sealed class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand>
{
    private readonly IAccountRepository _repository;
    private readonly IPasswordHasher<Account> _passwordHasher;

    public ChangePasswordHandler(IAccountRepository repository, IPasswordHasher<Account> passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetAsync(request.Id);

        if (account is null)
        {
            throw new AccountNotFoundException(request.Id);
        }
        
        account.ChangePassword(request.Password, request.NewPassword, _passwordHasher);

        await _repository.UpdateAsync(account);
    }
}