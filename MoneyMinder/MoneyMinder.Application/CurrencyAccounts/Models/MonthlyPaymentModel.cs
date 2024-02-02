using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;


public record MonthlyPaymentModel(Guid Id, string Name, DateTime Month, Currency Currency, decimal Amount, Category Category);
