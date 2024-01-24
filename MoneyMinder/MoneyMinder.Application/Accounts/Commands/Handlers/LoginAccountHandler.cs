using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MoneyMinder.Application.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.Accounts.Commands.Handlers;

public class LoginAccountHandler : IRequestHandler<LoginAccount, string>
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
    
    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<string> Handle(LoginAccount request, CancellationToken cancellationToken)
    {
        //var result = await _repository.GetAsync(new Guid("85bc49d3-9277-4cc6-8bce-ca80f5a62c64"));
        var account = await _repository.GetAsync(request.Email);
        
        if (account is null)
        {
            throw new AccountNotFoundByEmailException(request.Email);
        }
        
        account.VerifyPassword(request.Password, _passwordHasher);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new Claim(ClaimTypes.Email, account.Email),
            new Claim(ClaimTypes.Role, account.Role.ToString())
        };

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