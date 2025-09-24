using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record IncomeAddedDomainEvent(Income Income, CurrencyAccount CurrencyAccount) : IDomainEvent;