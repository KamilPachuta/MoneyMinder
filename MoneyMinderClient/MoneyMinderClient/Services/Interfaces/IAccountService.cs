using MoneyMinderClient.Core;
using MoneyMinderContracts.Requests.Accounts;
using MoneyMinderContracts.Responses.Accounts;

namespace MoneyMinderClient.Services.Interfaces;

public interface IAccountService
{
    
    Task<Result<LoginResponse>> LoginAsync(LoginAccountRequest request);
    Task<Result> RegisterAsync(CreateUserRequest request);
    Task LogoutAsync(); 
    public Task<bool> CheckAuthenticationAsync();
    
    public Task<Result> ChangePassword(ChangePasswordRequest request);
    public Task<Result> ChangeName(ChangeNameRequest request);
    public Task<Result> ChangePhoneNumber(ChangePhoneNumberRequest request);
    public Task<Result> ChangeAddress(ChangeAddressRequest request);
    

    // Task<string> GetTokenAsync();
    Task<string> GetNameAsync();
    // Task<Role> GetRoleAsync();
    Task<Result<GetUserDetailsResponse>> GetUserDetailsAsync();
    // Task<Result<GetNotificationsResponse>> GetNotificationsAsync();
    // Task<Result> ClearNotificationsAsync();
}