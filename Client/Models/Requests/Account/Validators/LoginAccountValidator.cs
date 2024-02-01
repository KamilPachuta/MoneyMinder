using Client.Models.Requests.Account.Commands;
using FluentValidation;

namespace Client.Models.Requests.Account.Validators;

public sealed class LoginAccountValidator : AbstractValidator<LoginAccountRequest>
{
    public LoginAccountValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(50);
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<LoginAccountRequest>.CreateWithOptions((LoginAccountRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    }; 
    
}