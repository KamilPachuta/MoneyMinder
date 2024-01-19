namespace MoneyMinder.Domain;

public class Extensions
{
    /*
     * Buissness Rulse:
     * 1. Budzet mozna stworzyc tylko dla bierzacego miesiaca
     * 2. W Budzecie mozna edytowac tylko nazwę
     *
     * 3. Savings to jakby konto na które mozna wplacac i wyplacac pieniadze z currencyaccount
     * 4. Savings ma jedno currency i tylko z tego mozna przelac z CurrencyAccount chyba że zrobić automatyczną konwersję
     *
     * 5. Transakcjie mozna utworzyc dla daty dzisiejszej do polnocy
     * 6. W transakcji nie można w ogóle edytować, mozna tylko usunąć
     * 7. Transakcje mozna usunąc, mechanizm cofania Balance ( w budget info o wydatkach jest pobierane na bierzaco)
     * 
     *
     * 8. Transakcje miesieczne mozna utworzyc dla miesiaca bierzacego albo przyszlego.
     * 9. Transakcje na bierzacy miesiac mozna "Akceptować" tj. ustalic dokladna kwote i przetworzyć -> dodanie transakcji i wyplucie nowego recordu z ustawionym kolejnym miesiacem
     * 10. Transakcja miesieczna usuwa sie na zasadzie usuniecai wpisu o kolejnej transakcji ( moze w przyszlosci jako feature dodac mozliwosc usunieca poprzednich transackji)
     *
     *
     *
     *
     *
     *
     * 
     */
}