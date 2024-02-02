using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses.Savings;

public class GetSavingsPortfolioResponse : IResponse
{
    public SavingsPortfolioModel SavingsPortfolio { get; set; }

    public GetSavingsPortfolioResponse(SavingsPortfolioModel savingsPortfolio)
    {
        SavingsPortfolio = savingsPortfolio;
    }

    public GetSavingsPortfolioResponse()
    {
        
    }
}