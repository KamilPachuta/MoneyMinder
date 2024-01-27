using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record EditExpenseRequest(Guid Id, Category Category, decimal ExpenseAmount);
    
