using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.WriteModels;


public record ExpenseWriteModel(Category Category, decimal Amount);
