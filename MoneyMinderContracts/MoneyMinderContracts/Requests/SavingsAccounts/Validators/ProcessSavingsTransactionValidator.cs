using FluentValidation;

namespace MoneyMinderContracts.Requests.SavingsAccounts.Validators;

public sealed class ProcessSavingsTransactionValidator : AbstractValidator<ProcessSavingsTransactionRequest>
{
    public ProcessSavingsTransactionValidator()
    {
        RuleFor(x => x.SavingsAccountId)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
        
        RuleFor(x => x.Date)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Date cannot be in the future.")
            .Must(d => d.Value.Year == DateTime.UtcNow.Year && d.Value.Month == DateTime.UtcNow.Month)
            .WithMessage("Date must be in the current month.");
        
        RuleFor(x => x.CurrencyDto)
            .IsInEnum();
        
        RuleFor(x => x.Amount)
            .NotEmpty();
        
        RuleFor(x => x.TransactionType)
            .IsInEnum();
    }
}