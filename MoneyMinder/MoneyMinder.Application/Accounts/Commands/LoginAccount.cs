using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record LoginAccount(string Email, string Password) : IRequest<string>;