using Client.Models.Enums;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class ConvertCurrencyToRequest
{
    public Guid Id { get; set; }
    public Currency From { get; set; }
    public Currency To { get; set; }
    public decimal Amount { get; set; }
    public decimal Coefficient { get; set; }

    public ConvertCurrencyToRequest()
    {
        // Konstruktor bezparametrowy
    }

    public ConvertCurrencyToRequest(Guid id, Currency from, Currency to, decimal amount, decimal coefficient)
    {
        Id = id;
        From = from;
        To = to;
        Amount = amount;
        Coefficient = coefficient;
    }
}