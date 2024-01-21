using MediatR;
using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

public class CreateAdminHandler : IRequestHandler<CreateAdmin>
{
    private readonly IAccountFactory _factory;
    private readonly IAccountRepository _repository;
    private readonly IPasswordHasher<Account> _passwordHasher;

    public CreateAdminHandler(IAccountFactory factory, IAccountRepository repository, IPasswordHasher<Account> passwordHasher)
    {
        _factory = factory;
        _repository = repository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task Handle(CreateAdmin request, CancellationToken cancellationToken)
    {
        var admin = _factory.CreateAdmin(request.email, request.password, _passwordHasher);

        await _repository.AddAsync(admin);
    }
}