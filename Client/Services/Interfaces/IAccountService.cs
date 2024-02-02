using Client.Models.Enums;
using Client.Models.Requests.Account.Commands;
using MoneyMinderClient.Models;

namespace Client.Services.Interfaces;

public interface IAccountService
{
    public Task<Result> LoginAsync(LoginAccountRequest request);
    public Task LogoutAsync();
    public Task<Result> RegisterAsync(CreateUserRequest request);

    public Task<bool> CheckAuthenticationAsync();

    public Task<string> GetToken();
    public Task<string> GetName();
    public Task<Role> GetRole();
    public Task<Guid> GetId();

}