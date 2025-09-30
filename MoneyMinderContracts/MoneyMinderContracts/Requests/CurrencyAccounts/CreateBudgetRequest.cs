using MoneyMinderContracts.Enums;
using MoneyMinderContracts.WriteModels;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public abstract record CreateBudgetRequest(Guid CurrencyAccountId, DateTime Date, CurrencyDto CurrencyDto, IEnumerable<LimitWriteModelDto> Limits);
