using Client.Models.Enums;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class AcceptMonthlyPaymentRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }


    public AcceptMonthlyPaymentRequest()
    {
    }

    public AcceptMonthlyPaymentRequest(Guid id, string name, decimal amount)
    {
        Id = id;
        Name = name;
        Amount = amount;
    }
}