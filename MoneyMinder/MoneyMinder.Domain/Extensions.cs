namespace MoneyMinder.Domain;

public class Extensions
{
    /*
     /*
     * Business Rules:
     * 1. A budget can only be created for the current month.
     * 2. In the budget, only the name can be edited.
     * 3. Savings act as an account where you can deposit and withdraw money from a currency account.
     * 4. Savings have a single currency, and transfers can only be made from a Currency Account unless automatic conversion is implemented.
     * 5. Transactions can be created for today's date until midnight.
     * 6. Transactions cannot be edited at all; they can only be deleted.
     * 7. Transactions can be deleted, which will affect the balance (budget info about expenses is updated in real-time).
     * 8. Monthly transactions can be created for the current month or the future.
     * 9. Transactions for the current month can be "Approved," i.e., the exact amount can be set and processed -> adding the transaction and generating a new record with the next month set.
     * 10. Monthly transactions are deleted by removing the entry of the respective transaction (in the future, a feature to delete previous transactions could be added).
     *
     *
     *
     *
     *
     *
     *
     *
     *
     * 
     *
     *
     * 
     * Buissness Rulse:
     * 1. Budzet mozna stworzyc tylko dla bierzacego miesiaca
     * 2. W Budzecie mozna edytowac tylko nazwę
     * 3. Savings to jakby konto na które mozna wplacac i wyplacac pieniadze z currencyaccount
     * 4. Savings ma jedno currency i tylko z tego mozna przelac z CurrencyAccount chyba że zrobić automatyczną konwersję
     * 5. Transakcjie mozna utworzyc dla daty dzisiejszej do polnocy
     * 6. W transakcji nie można w ogóle edytować, mozna tylko usunąć
     * 7. Transakcje mozna usunąc, mechanizm cofania Balance ( w budget info o wydatkach jest pobierane na bierzaco)
     * 8. Transakcje miesieczne mozna utworzyc dla miesiaca bierzacego albo przyszlego.
     * 9. Transakcje na bierzacy miesiac mozna "Akceptować" tj. ustalic dokladna kwote i przetworzyć -> dodanie transakcji i wyplucie nowego recordu z ustawionym kolejnym miesiacem
     * 10. Transakcja miesieczna usuwa sie na zasadzie usunięcia wpisu o kolejnej transakcji ( moze w przyszlosci jako feature dodac mozliwosc usunieca poprzednich transackji)
     *
     */
}