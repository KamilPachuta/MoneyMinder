namespace Client.Models.Requests.CurrencyAccount.Commands;

public class DeleteCurrencyAccountRequest
{
    public Guid Id { get; set; }

    public DeleteCurrencyAccountRequest()
    {
    }

    public DeleteCurrencyAccountRequest(Guid id)
    {
        Id = id;
    }
}