using MoneyMinderContracts.Enums;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class AddPaymentRequest
{
    public Guid CurrencyAccountId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public CurrencyDto CurrencyDto { get; set; }
    public decimal Amount { get; set; }
    public CategoryDto CategoryDto { get; set; }

    public AddPaymentRequest()
    {
    }
    
    public AddPaymentRequest(Guid currencyAccountId, string name, DateTime date, CurrencyDto currencyDto, decimal amount, CategoryDto categoryDto)
    {
        CurrencyAccountId = currencyAccountId;
        Name = name;
        Date = date;
        CurrencyDto = currencyDto;
        Amount = amount;
        CategoryDto = categoryDto;
    }
}
