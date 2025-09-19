using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Repositories;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

internal sealed class LoginAccountHandler : IRequestHandler<LoginAccountCommand, string>
{
    private readonly IAccountRepository _repository;
    private readonly AuthenticationSettings _authenticationSettings;
    private readonly IPasswordHasher<Account> _passwordHasher;

    public LoginAccountHandler(IAccountRepository repository, AuthenticationSettings authenticationSettings, IPasswordHasher<Account> passwordHasher)
    {
        _repository = repository;
        _authenticationSettings = authenticationSettings;
        _passwordHasher = passwordHasher;
    }
    

    public async Task<string> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetAsync(request.Email);
        
        if (account is null)
        {
            throw new AccountNotFoundByEmailException(request.Email);
        }
        
        account.VerifyPassword(request.Password, _passwordHasher);

        var claims = new List<Claim>()
        {
            new (ClaimTypes.NameIdentifier, account.Id.ToString()),
            new (ClaimTypes.Email, account.Email),
            new (ClaimTypes.Role, account.Role.ToString())
        };
        if (account.User is not null)
        {
            claims.Add(new Claim(ClaimTypes.Name, account.User.Name.ToString()));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);


        var token = new JwtSecurityToken(
            _authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}