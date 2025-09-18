using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record LoginAccountCommand(string Email, string Password) : IRequest<string>;