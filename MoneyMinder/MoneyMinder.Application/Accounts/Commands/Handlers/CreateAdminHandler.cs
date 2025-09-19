using MediatR;
using Microsoft.AspNetCore.Identity;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Application.Accounts.Services;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

internal sealed class CreateAdminHandler : IRequestHandler<CreateAdminCommand>
{
    private readonly IAccountFactory _factory;
    private readonly IAccountRepository _repository;
    private readonly IAccountReadService _readService;
    private readonly IPasswordHasher<Account> _passwordHasher;

    public CreateAdminHandler(IAccountFactory factory, IAccountRepository repository, IAccountReadService readService, IPasswordHasher<Account> passwordHasher)
    {
        _factory = factory;
        _repository = repository;
        _readService = readService;
        _passwordHasher = passwordHasher;
    }
    
    public async Task Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        if (await _readService.CheckUnique(request.Email))
        {
            throw new AccountAlreadyExistException(request.Email);
        }
        
        var admin = _factory.CreateAdmin(request.Email, request.Password, _passwordHasher);

        await _repository.AddAsync(admin);
    }
}