using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;


public record CurrencyAccountNameChangedDomainEvent(CurrencyAccountName OldName, CurrencyAccountName NewName, CurrencyAccount CurrencyAccount ) : IDomainEvent;