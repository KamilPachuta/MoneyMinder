using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record CreateBudgetRequest(Guid CurrencyAccountId, DateTime Date, Currency Currency, IEnumerable<LimitWriteModel> Limits);
