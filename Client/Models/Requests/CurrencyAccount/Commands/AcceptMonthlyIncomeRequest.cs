using Client.Models.Enums;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class AcceptMonthlyIncomeRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }

    public AcceptMonthlyIncomeRequest()
    {
    }

    public AcceptMonthlyIncomeRequest(Guid id, string name, decimal amount)
    {
        Id = id;
        Name = name;
        Amount = amount;
    }
}