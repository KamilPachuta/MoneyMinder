namespace Client.Models.Requests.SavingsPortfolios.Commands;

public class DeleteSavingsPortfolioRequest
{
    public Guid Id { get; set; }

    public DeleteSavingsPortfolioRequest()
    {
    }

    public DeleteSavingsPortfolioRequest(Guid id)
    {
        Id = id;
    }
}