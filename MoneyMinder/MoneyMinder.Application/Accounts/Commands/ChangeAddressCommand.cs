using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record ChangeAddressCommand(Guid Id, string Country, string City, string PostalCode, string Street) : IRequest;