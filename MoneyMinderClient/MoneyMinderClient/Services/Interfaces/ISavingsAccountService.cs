using MoneyMinderClient.Core;
using MoneyMinderContracts.Responses.SavingsAccounts;

namespace MoneyMinderClient.Services.Interfaces;

public interface ISavingsAccountService
{
    public Task<Result<GetSavingsAccountNamesResponse>> GetSavingsAccountNames();
}