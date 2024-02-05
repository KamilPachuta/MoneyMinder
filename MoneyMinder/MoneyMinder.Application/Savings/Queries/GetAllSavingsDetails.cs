using MediatR;
using MoneyMinder.Application.Savings.Models;

namespace MoneyMinder.Application.Savings.Queries;

public record GetAllSavingsDetails(Guid Id) : IRequest<IEnumerable<SavingsPortfolioModel>>;
