using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses.Savings;

public class GetSavingsPortfolioIdByNameResponse : IResponse
{
    public Guid Id { get; set; }

    public GetSavingsPortfolioIdByNameResponse()
    {
        
    }
    
    public GetSavingsPortfolioIdByNameResponse(Guid id)
    {
        Id = id;
    }
}