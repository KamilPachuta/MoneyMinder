using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;
using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record CurrencyAccountNameChangedDomainEvent(CurrencyAccountName OldName, CurrencyAccountName NewName, CurrencyAccount CurrencyAccount) : IDomainEvent;