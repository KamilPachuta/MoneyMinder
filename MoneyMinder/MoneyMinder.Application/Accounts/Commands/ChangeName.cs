using MediatR;
using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Application.Accounts.Commands;

public record ChangeName(Guid Id, string FirstName, string LastName) : IRequest;