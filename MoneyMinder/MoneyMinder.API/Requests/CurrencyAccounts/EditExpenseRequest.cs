using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record EditExpenseRequest(Guid CurrencyAccountId, Category Category, decimal ExpenseAmount);
    
