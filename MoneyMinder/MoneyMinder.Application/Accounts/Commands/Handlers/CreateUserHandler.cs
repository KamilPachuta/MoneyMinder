using MediatR;
using Microsoft.AspNetCore.Identity;
using MoneyMinder.Application.Accounts.Services;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

internal sealed class CreateUserHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IAccountFactory _factory;
    private readonly IAccountRepository _repository;
    private readonly IAccountReadService _readService;
    private readonly IPasswordHasher<Account> _passwordHasher;

    public CreateUserHandler(IAccountFactory factory, IAccountRepository repository, IAccountReadService readService, IPasswordHasher<Account> passwordHasher)
    {
        _factory = factory;
        _repository = repository;
        _readService = readService;
        _passwordHasher = passwordHasher;
    }
    
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _readService.CheckUnique(request.Email))
        {
            throw new AccountAlreadyExistException(request.Email);
        }

        var name = new UserName(request.FirstName, request.LastName);

        var phone = new UserPhoneNumber(request.PhoneCode, request.PhoneNumber);
        
        var user = _factory.CreateUser(request.Email, request.Password, _passwordHasher,
            name, phone, request.BirthDate, request.Gender, request.Country, request.City, request.PostalCode, request.Street);

        await _repository.AddAsync(user);
    }
}