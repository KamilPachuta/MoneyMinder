using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses;

public class GetBudgetDetailsResponse : IResponse
{
    public BudgetModel Budget { get; set; }

    public GetBudgetDetailsResponse()
    {
        
    }
    
    public GetBudgetDetailsResponse(BudgetModel budget)
    {
        Budget = budget;
    }
}