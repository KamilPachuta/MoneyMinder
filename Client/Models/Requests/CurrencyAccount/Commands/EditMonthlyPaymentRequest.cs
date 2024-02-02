using Client.Models.Enums;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class EditMonthlyPaymentRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal NewAmount { get; set; }
    public Currency NewCurrency { get; set; }

    public EditMonthlyPaymentRequest()
    {
        // Konstruktor bezparametrowy
    }

    public EditMonthlyPaymentRequest(Guid id, string name, string newName, decimal newAmount, Currency newCurrency)
    {
        Id = id;
        Name = name;
        NewAmount = newAmount;
        NewCurrency = newCurrency;
    }
}