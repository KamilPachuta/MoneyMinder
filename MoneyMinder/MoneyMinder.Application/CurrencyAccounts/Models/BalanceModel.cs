using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;


public record BalanceModel(Guid Id, Currency Currency, decimal Amount);
