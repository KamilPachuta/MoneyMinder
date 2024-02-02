using MediatR;
using MoneyMinder.Application.Savings.Models;

namespace MoneyMinder.Application.Savings.Queries;

public record GetSavingsNames(Guid Id) : IRequest<IEnumerable<SavingsPortfolioNameModel>>;