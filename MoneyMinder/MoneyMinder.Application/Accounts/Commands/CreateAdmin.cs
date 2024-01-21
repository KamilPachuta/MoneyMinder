using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record CreateAdmin(string Email, string Password) : IRequest;