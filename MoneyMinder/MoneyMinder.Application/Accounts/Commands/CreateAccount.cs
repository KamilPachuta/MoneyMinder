using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record CreateAdmin(string email, string password) : IRequest;