namespace Client.Models.Requests.CurrencyAccount.Commands;

public class DeleteBudgetRequest
{
    public Guid Id { get; set; }

    public DeleteBudgetRequest()
    {
        
    }
    public DeleteBudgetRequest(Guid id)
    {
        Id = id;
    }
}