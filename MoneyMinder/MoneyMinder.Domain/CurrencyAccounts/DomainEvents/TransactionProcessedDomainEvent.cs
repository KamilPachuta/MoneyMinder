using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record TransactionProcessedDomainEvent(Transaction Transaction, CurrencyAccount CurrencyAccount) : IDomainEvent;