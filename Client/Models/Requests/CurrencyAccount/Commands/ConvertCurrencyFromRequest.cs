using Client.Models.Enums;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class ConvertCurrencyFromRequest
{
    public Guid Id { get; set; }
    public Currency From { get; set; }
    public Currency To { get; set; }
    public decimal Amount { get; set; }
    public decimal Coefficient { get; set; }

    public ConvertCurrencyFromRequest()
    {
        // Konstruktor bezparametrowy
    }

    public ConvertCurrencyFromRequest(Guid id, Currency from, Currency to, decimal amount, decimal coefficient)
    {
        Id = id;
        From = from;
        To = to;
        Amount = amount;
        Coefficient = coefficient;
    }
}