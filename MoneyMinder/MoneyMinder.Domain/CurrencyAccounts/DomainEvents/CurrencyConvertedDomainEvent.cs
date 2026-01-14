using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record CurrencyConvertedDomainEvent(DefinedCurrency From, DefinedCurrency To, Amount Amount, Amount Coefficient, CurrencyAccount CurrencyAccount) : IDomainEvent;
