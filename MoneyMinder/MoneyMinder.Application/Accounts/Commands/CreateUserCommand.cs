using MediatR;
using MoneyMinder.Domain.Accounts.Enums;

namespace MoneyMinder.Application.Accounts.Commands;

public record CreateUserCommand(string Email, string Password, string FirstName, string LastName, 
    string PhoneCode, string PhoneNumber, DateTime BirthDate, Gender Gender, string Country, string City, string PostalCode, string Street) : IRequest;