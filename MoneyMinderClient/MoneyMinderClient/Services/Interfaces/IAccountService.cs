using MoneyMinderClient.Core;
using MoneyMinderContracts.Requests.Accounts;

using MoneyMinderContracts.Responses.Accounts;

namespace MoneyMinderClient.Services.Interfaces;

public interface IAccountService
{
    
    Task<Result<LoginResponse>> LoginAsync(LoginAccountRequest request); // zwraca token
    Task<Result> RegisterAsync(CreateUserRequest request);
    Task LogoutAsync(); 
    public Task<bool> CheckAuthenticationAsync();
    

    // Task<string> GetTokenAsync();
    Task<string> GetNameAsync();
    // Task<Role> GetRoleAsync();
    // Task<Guid> GetIdAsync();
    // Task<Result<GetPersonalInfoResponse>> GetPersonalInfoAsync();
    // Task<Result<GetNotificationsResponse>> GetNotificationsAsync();
    // Task<Result> ClearNotificationsAsync();
}