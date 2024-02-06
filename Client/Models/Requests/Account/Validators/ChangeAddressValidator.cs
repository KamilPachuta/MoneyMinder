using Client.Models.Requests.Account.Commands;
using FluentValidation;

namespace Client.Models.Requests.Account.Validators;

public sealed class ChangeAddressValidator : AbstractValidator<ChangeAddressRequest>
{
    public ChangeAddressValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);
        
        RuleFor(x => x.City)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
        
        RuleFor(x => x.Street)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);
            
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ChangeAddressRequest>.CreateWithOptions((ChangeAddressRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}