using MediatR;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record CreateCurrencyAccount(string Name) : IRequest;