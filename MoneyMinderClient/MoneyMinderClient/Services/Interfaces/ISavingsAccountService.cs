using MoneyMinderClient.Core;
using MoneyMinderContracts.Requests.SavingsAccounts;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinderClient.Services.Interfaces;

public interface ISavingsAccountService
{
    public Task<Result> PostSavingsAccountAsync(CreateSavingsAccountRequest request);
    public Task<Result> PatchSavingsAccountAsync(ChangeSavingsAccountNameRequest request);
    public Task<Result> DeleteSavingsAccountAsync(DeleteSavingsAccountRequest request);
    
    public Task<Result<GetSavingsAccountNamesResponse>> GetSavingsAccountNames();
    public Task<Result<GetSavingsAccountsDetailsResponse>> GetSavingsAccountsDetailsAsync();
    
}