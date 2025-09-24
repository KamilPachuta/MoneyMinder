using MoneyMinder.Domain.Shared.Enums;
using MoneyMinder.Domain.Shared.Exceptions;

namespace MoneyMinder.Domain.Shared.ValueObjects;

public record DefinedCurrency
{
    public Currency Currency { get; }

    public DefinedCurrency(Currency currency)
    {
        if (!Enum.IsDefined(typeof(Currency), currency))
        {
            throw new InvalidDefinedCurrencyException(currency);
        }
        
        Currency = currency;
    }

    public string GetSymbol()
        => GetSymbol(this);

    public string GetName()
        => GetName(this);
    
    public static implicit operator Currency(DefinedCurrency definedCurrency)
        => definedCurrency.Currency;
    
    public static implicit operator DefinedCurrency(Currency currency)
        => new(currency);
    
    private static string GetSymbol(DefinedCurrency currency) =>
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
            _ => throw new InvalidDefinedCurrencyException(currency.Currency)
        };

        private static string GetName(DefinedCurrency currency) =>
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
                _ => throw new InvalidDefinedCurrencyException(currency.Currency)
            };
}