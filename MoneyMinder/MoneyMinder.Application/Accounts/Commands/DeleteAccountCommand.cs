using MediatR;

namespace MoneyMinder.Application.Accounts.Commands;

public record DeleteAccountCommand(Guid Id, string Password) : IRequest;
