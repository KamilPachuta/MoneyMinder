using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record ChangePhoneNumberCommand(Guid Id, string Code, string Number) : IRequest;