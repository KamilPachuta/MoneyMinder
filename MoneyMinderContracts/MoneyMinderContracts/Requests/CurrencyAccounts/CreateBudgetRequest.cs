using MoneyMinderContracts.Models.Dtos;
using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public class CreateBudgetRequest
{
    public Guid CurrencyAccountId { get; set; }
    public CurrencyDto CurrencyDto { get; set; }
    public IEnumerable<LimitDto> Limits { get; set; }

    public CreateBudgetRequest()
    {
    }
    
    public CreateBudgetRequest(Guid currencyAccountId, CurrencyDto currencyDto, IEnumerable<LimitDto> limits)
    {
        CurrencyAccountId = currencyAccountId;
        CurrencyDto = currencyDto;
        Limits = limits;
    }
}

