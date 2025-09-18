using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record ChangeNameCommand(Guid Id, string FirstName, string LastName) : IRequest;