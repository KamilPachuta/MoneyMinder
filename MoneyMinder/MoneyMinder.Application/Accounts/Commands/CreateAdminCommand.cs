using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record CreateAdminCommand(string Email, string Password) : IRequest;