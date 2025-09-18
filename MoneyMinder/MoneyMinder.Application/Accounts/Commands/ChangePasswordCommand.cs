using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record ChangePasswordCommand(Guid Id, string Password, string NewPassword) : IRequest;