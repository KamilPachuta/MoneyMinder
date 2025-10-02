namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class DeleteBudgetRequest
{
    public Guid CurrencyAccountId { get; set; }

    public DeleteBudgetRequest()
    {
    }
    
    public DeleteBudgetRequest(Guid currencyAccountId)
    {
        CurrencyAccountId = currencyAccountId;
    }
}
