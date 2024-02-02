using Client.Models.Enums;

namespace Client.Models.Requests.SavingsPortfolios.Commands;

public class CreateSavingsPortfolioRequest
{
    public string Name { get; set; }
    public Currency Currency { get; set; }
    public decimal PlannedAmount { get; set; }

    public CreateSavingsPortfolioRequest()
    {
        // Konstruktor bezparametrowy
    }

    public CreateSavingsPortfolioRequest(string name, Currency currency, decimal plannedAmount)
    {
        Name = name;
        Currency = currency;
        PlannedAmount = plannedAmount;
    }
}