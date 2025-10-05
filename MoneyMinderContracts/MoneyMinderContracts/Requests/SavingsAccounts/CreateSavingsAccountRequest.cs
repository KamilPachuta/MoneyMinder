using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Requests.SavingsAccounts;

public class CreateSavingsAccountRequest
{
    public string Name { get; set; } = string.Empty;
    public CurrencyDto CurrencyDto { get; set; }
    public decimal PlannedAmount { get; set; }

    public CreateSavingsAccountRequest()
    {
    }
    
    public CreateSavingsAccountRequest(string name, CurrencyDto currencyDto, decimal plannedAmount)
    {
        Name = name;
        CurrencyDto = currencyDto;
        PlannedAmount = plannedAmount;
    }
}

