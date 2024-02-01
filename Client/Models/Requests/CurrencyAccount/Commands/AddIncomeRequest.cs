using Client.Models.Enums;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class AddIncomeRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime? Date { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }

    public AddIncomeRequest()
    {
        
    }
    
    public AddIncomeRequest(Guid id, string name, DateTime date, Currency currency, decimal amount)
    {
        Id = id;
        Name = name;
        Date = date;
        Currency = currency;
        Amount = amount;
    }
}