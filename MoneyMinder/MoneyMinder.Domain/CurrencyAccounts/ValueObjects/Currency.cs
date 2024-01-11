using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.CurrencyAccounts.Exceptions;

namespace MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

public abstract record Currency()
{
    public static Currency Create(SupportedCurrency currency)
    {
        switch (currency)
        {
            case SupportedCurrency.PLN:
                return new PLN();
            case SupportedCurrency.EUR:
                return new EUR();
            case SupportedCurrency.USD:
                return new USD();
            case SupportedCurrency.CZK:
                return new CZK();
            case SupportedCurrency.JPY:
                return new JPY();
            case SupportedCurrency.GBP:
                return new GBP();
            case SupportedCurrency.AED:
                return new AED();
        }

        throw new UnsupportedCurrencyException(currency.ToString());
    }
    public static Currency Create(string code)
    {
        switch (code)
        {
            case "PLN":
                return new PLN();
            case "EUR":
                return new EUR();
            case "USD":
                return new USD();
            case "CZK":
                return new CZK();
            case "JPY":
                return new JPY();
            case "GBP":
                return new GBP();
            case "AED":
                return new AED();
            default:
                throw new UnsupportedCurrencyException(code);
        }
    }
    
    public abstract string Name();
    public override abstract string ToString();
    public record PLN : Currency
    {
        public override string Name()
            => "Polski zloty";

        public override string ToString()
            => "PLN";
    }
    
    public record EUR : Currency
    {
        public override string Name()
            => "Euro";
        public override string ToString()
            => "EUR";
    }
    
    public record USD : Currency
    {
        public override string Name()
            => "American Dolar";
        public override string ToString()
            => "USD";
    }
    
    public record CZK : Currency
    {
        public override string Name()
            => "Czech crowns";
        public override string ToString()
            => "EUR";
    }
    
    public record JPY : Currency
    {
        public override string Name()
            => "Yen";
        public override string ToString()
            => "EUR";
    }
    
    public record GBP : Currency
    {
        public override string Name()
            => "Sterling";
        public override string ToString()
            => "GBP";
    }
    
    public record AED : Currency
    {
        public override string Name()
            => "Dirham";
        public override string ToString()
            => "AED";
    }
    
    
}