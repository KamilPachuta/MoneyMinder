using FluentValidation;
using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.SavingsPortfolios.Enums;

namespace MoneyMinder.API.Requests.SavingsPortfolios.Validators;

public sealed class ProcessSavingsTransactionValidator : AbstractValidator<ProcessSavingsTransactionRequest>
{
    public ProcessSavingsTransactionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Date)
            .NotEmpty();

        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");

        RuleFor(x => x.Amount)
            .NotEmpty();

        RuleFor(x => x.Type)
            .Must(value => Enum.IsDefined(typeof(TransactionType), value))
            .WithMessage("Invalid value for the Type field.");


    }
}