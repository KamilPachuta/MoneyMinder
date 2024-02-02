using Client.Models.Enums;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class EditMonthlyIncomeRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal NewAmount { get; set; }
    public Currency NewCurrency { get; set; }

    public EditMonthlyIncomeRequest()
    {
        // Konstruktor bezparametrowy
    }

    public EditMonthlyIncomeRequest(Guid id, string name, decimal newAmount, Currency newCurrency)
    {
        Id = id;
        Name = name;
        NewAmount = newAmount;
        NewCurrency = newCurrency;
    }
}