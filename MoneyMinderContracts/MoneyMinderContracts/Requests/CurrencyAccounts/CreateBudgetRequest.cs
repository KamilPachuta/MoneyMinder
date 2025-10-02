using MoneyMinderContracts.Enums;
using MoneyMinderContracts.WriteModels;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class CreateBudgetRequest
{
    public Guid CurrencyAccountId { get; set; }
    public DateTime Date { get; set; }
    public CurrencyDto CurrencyDto { get; set; }
    public IEnumerable<LimitWriteModelDto> Limits { get; set; }

    public CreateBudgetRequest()
    {
    }
    
    public CreateBudgetRequest(Guid currencyAccountId, DateTime date, CurrencyDto currencyDto, IEnumerable<LimitWriteModelDto> limits)
    {
        CurrencyAccountId = currencyAccountId;
        Date = date;
        CurrencyDto = currencyDto;
        Limits = limits;
    }
}

