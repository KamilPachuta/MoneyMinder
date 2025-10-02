using MoneyMinderContracts.Enums;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class AddIncomeRequest
{
    public Guid CurrencyAccountId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public CurrencyDto CurrencyDto { get; set; }
    public decimal Amount { get; set; }

    public AddIncomeRequest()
    {
    }
    
    public AddIncomeRequest(Guid currencyAccountId, string name, DateTime date, CurrencyDto currencyDto, decimal amount)
    {
        CurrencyAccountId = currencyAccountId;
        Name = name;
        Date = date;
        CurrencyDto = currencyDto;
        Amount = amount;
    }
}
