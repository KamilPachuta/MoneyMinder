namespace MoneyMinder.Domain;

public class Extensions
{
    /*
     * Buissness Rulse:
     * 1. Budzet mozna stworzyc tylko dla bierzacego miesiaca
     * 2. W Budzecie mozna edytowac wszystko
     *
     * 3. Savings to jakby konto na które mozna wplacac i wyplacac pieniadze z currencyaccount
     * 4. Savings ma jedno currency i tylko z tego mozna przelac z CurrencyAccount chyba że zrobić automatyczną konwersję
     *
     *
     *
     * 5. Transakcje miesieczne mozna utworzyc dla miesiaca bierzacego albo przyszlego.
     * 6. Transakcje na bierzacy miesiac mozna "Akceptować" tj. ustalic dokladna kwote i przetworzyć -> dodanie transakcji i wyplucie nowego recordu z ustawionym kolejnym miesiacem
     * 
     */
}