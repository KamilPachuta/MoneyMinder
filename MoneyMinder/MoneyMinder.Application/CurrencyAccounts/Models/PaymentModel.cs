using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;


public record PaymentModel(Guid Id, string Name, DateTime Date, Currency Currency, decimal Amount, Category Category);
