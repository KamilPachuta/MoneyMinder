using MoneyMinder.Domain.Shared.Abstractions;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Domain.CurrencyAccounts.DomainEvents;

public record TransactionProcessedDomainEvent(Transaction Transaction, CurrencyAccount CurrencyAccount) : IDomainEvent;