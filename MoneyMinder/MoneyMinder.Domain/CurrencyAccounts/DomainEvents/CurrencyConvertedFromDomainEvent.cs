using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record CurrencyConvertedFromDomainEvent(Currency From, Currency To, decimal amount, decimal coefficient, CurrencyAccount CurrencyAccount) : IDomainEvent;