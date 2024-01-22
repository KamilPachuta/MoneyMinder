using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record ChangePassword(Guid Id, string Password, string NewPassword) : IRequest;