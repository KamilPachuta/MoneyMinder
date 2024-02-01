using Client.Models.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record RemoveExpenseRequest(Guid Id, Category Category);
