using MediatR;
using MoneyMinder.Application.Savings.Models;

namespace MoneyMinder.Application.Savings.Queries;

public record GetSavingsPortfolio(Guid Id) : IRequest<SavingsPortfolioModel>;