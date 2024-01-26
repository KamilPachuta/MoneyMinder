using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.SavingsPortfolios;

public record CreateSavingsPortfolioRequest(string Name, Currency Currency, decimal PlannedAmount);