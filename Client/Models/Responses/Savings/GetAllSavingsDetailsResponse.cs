using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses.Savings;

public class GetAllSavingsDetailsResponse : IResponse
{
    public IEnumerable<SavingsPortfolioModel> SavingsPortfolios { get; set; }

    public GetAllSavingsDetailsResponse()
    {
        
    }
    
    public GetAllSavingsDetailsResponse(IEnumerable<SavingsPortfolioModel> savingsPortfolios)
    {
        SavingsPortfolios = savingsPortfolios;
    }

    
    
}