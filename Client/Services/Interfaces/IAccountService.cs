using Client.Models.Enums;
using Client.Models.Requests.Account.Commands;
using Client.Models.Responses.Accounts;
using MoneyMinderClient.Models;

namespace Client.Services.Interfaces;

public interface IAccountService
{
    public Task<Result> LoginAsync(LoginAccountRequest request);
    public Task LogoutAsync();
    public Task<Result> RegisterAsync(CreateUserRequest request);

    public Task<bool> CheckAuthenticationAsync();
    
    public Task<Result> ChangePassword(ChangePasswordRequest request);
    public Task<Result> ChangeName(ChangeNameRequest request);
    public Task<Result> ChangePhoneNumber(ChangePhoneNumberRequest request);
    public Task<Result> ChangeAddress(ChangeAddressRequest request);

    public Task<string> GetToken();
    public Task<string> GetName();
    public Task<Role> GetRole();
    public Task<Guid> GetId();

    public Task<Result<GetPersonalInfoResponse>> GetPersonalInfo();


}