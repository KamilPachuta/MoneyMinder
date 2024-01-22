using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record ChangePhoneNumber(Guid Id, string Code, string Number) : IRequest;