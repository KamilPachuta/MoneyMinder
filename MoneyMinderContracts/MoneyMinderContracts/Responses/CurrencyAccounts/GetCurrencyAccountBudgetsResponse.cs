using MoneyMinderContracts.Models.Dtos;

namespace MoneyMinderContracts.Responses.CurrencyAccounts;

public record GetCurrencyAccountBudgetsResponse(IEnumerable<BudgetDto> Budgets);