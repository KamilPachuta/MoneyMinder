using MediatR;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.SavingsPortfolios.Enums;

namespace MoneyMinder.Application.Savings.Commands;

public record ProcessSavingsTransactionCommand(Guid AccountId, Guid SavingsPortfolioId, string Name, DateTime Date, Currency Currency, decimal Amount, TransactionType Type) : IRequest;