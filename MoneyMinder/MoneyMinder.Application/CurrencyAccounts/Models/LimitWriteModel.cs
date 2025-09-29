using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

public record LimitWriteModel(Category Category, decimal Amount);