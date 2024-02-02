using Client.Models.Requests.SavingsPortfolios.Commands;
using Client.Models.Responses.Savings;
using MoneyMinderClient.Models;

namespace Client.Services.Interfaces;

public interface ISavingsService
{
    public Task<Result> PutSavings(CreateSavingsPortfolioRequest request);
    public Task<Result> DeleteSavings(DeleteSavingsPortfolioRequest request);
    public Task<Result> PostSavingsName(ChangeSavingsNameRequest request);
    public Task<Result> PostSavingsPlannedAmount(ChangeSavingsPlannedAmountRequest request);
    public Task<Result> PostTransaction(ProcessSavingsTransactionRequest request);

    public Task<Result<GetSavingsPortfolioIdByNameResponse>> GetIdByName(string name);
    public Task<Result<GetSavingsNamesResponse>> GetSavingsNames();
    public Task<Result<GetSavingsPortfolioResponse>> GetSavingsPortfolio(Guid id);


    // public Task<Result> PutCurrencyAccount(CreateCurrencyAccountRequest request);
    // public Task<Result<GetCurrencyAccountNamesResponse>> GetCurrencyAccountNames();


}