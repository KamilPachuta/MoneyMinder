using MoneyMinder.Domain.Shared.Enum;
using MoneyMinder.Domain.Shared.Exceptions;

namespace MoneyMinder.Domain.Shared.ValueObjects;

public record TransactionCurrency
{
    public Currency Currency { get; }

    public TransactionCurrency(Currency currency)
    {
        if (!System.Enum.IsDefined(typeof(Currency), currency))
        {
            throw new InvalidTransactionCurrencyException(currency);
        }
        
        Currency = currency;
    }

    public string GetSymbol()
        => GetSymbol(this);

    public string GetName()
        => GetName(this);
    
    private static string GetSymbol(TransactionCurrency currency) =>
        currency.Currency switch
        {
            Currency.USD => "$",
            Currency.EUR => "€",
            Currency.GBP => "£",
            Currency.CHF => "CHF",
            Currency.JPY => "¥",
            Currency.AUD => "A$",
            Currency.CAD => "C$",
            Currency.CNY => "¥",
            Currency.SEK => "kr",
            Currency.PLN => "zł",
            _ => throw new InvalidTransactionCurrencyException(currency.Currency)
        };

        private static string GetName(TransactionCurrency currency) =>
            currency.Currency switch
            {
                Currency.USD => "Dolar amerykański",
                Currency.EUR => "Euro",
                Currency.GBP => "Funt szterling",
                Currency.CHF => "Frank szwajcarski",
                Currency.JPY => "Jen japoński",
                Currency.AUD => "Dolar australijski",
                Currency.CAD => "Dolar kanadyjski",
                Currency.CNY => "Juan chiński",
                Currency.SEK => "Korona szwedzka",
                Currency.PLN => "Polski złoty",
                _ => throw new InvalidTransactionCurrencyException(currency.Currency)
            };
}