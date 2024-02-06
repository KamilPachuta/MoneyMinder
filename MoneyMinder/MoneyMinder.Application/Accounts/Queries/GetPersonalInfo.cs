using MediatR;
using MoneyMinder.Application.Accounts.Models;

namespace MoneyMinder.Application.Accounts.Queries;

public record GetPersonalInfo(Guid Id) : IRequest<PersonalInfoModel>;