using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record ChangeAddress(Guid Id, string Country, string City, string PostalCode, string Street) : IRequest;