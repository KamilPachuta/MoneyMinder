using MediatR;

namespace MoneyMinder.Application.CurrencyAccounts.Queries;

public record GetCurrencyAccount(Guid id) : IRequest;