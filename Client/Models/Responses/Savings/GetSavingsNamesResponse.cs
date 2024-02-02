using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses.Savings;

public class GetSavingsNamesResponse : IResponse
{
    public IEnumerable<SavingsPortfolioNameModel> SavingsportfolioNames { get; }

    public GetSavingsNamesResponse()
    {
        
    }
    
    public GetSavingsNamesResponse(IEnumerable<SavingsPortfolioNameModel> savingsportfolioNames)
    {
        SavingsportfolioNames = savingsportfolioNames;
    }
}