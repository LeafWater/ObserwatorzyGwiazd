# ObserwatorzyNieba
Aplikacja mobilna na temat zjawisk astronomicznych (C#, Xamarin)

## Cel
Aplikacja została stworzona na urządzenia mobilne. Jest to niekomercyjny projekt. Aplikacja jest skierowana do osób interesującymi się zjawiskami astronomicznymi.
Dostarcza informacji na temat Słońca, Księżyca, gwiazdozbiorów oraz dostarcza informacji o nadchodzących wydarzeniach związanych z astronomią.

## Technologie
* C#
* Xamarin.Forms, crossed-platform
* Pakiety NuGet

## Uruchomienie
Repozytorium nie zawiera całego, kompletnego projektu. W folderze "Files with code" znajdują się tylko pliki z kodem .xaml i .cs. 
Mają one za zadanie ukazać, jak zostały rozwiązane funkcjonalności aplikacji, jak zostały skonstruowane algorytmy obliczające fazy Księżyca czy godziny wschodów/zachodów Słońca.

## Działanie aplikacji
Aplikacja została przetestowana na Android i Universal Windows Platform (UWP). Poniżej zostanie pokrótce opisane działanie aplikacji na urządzeniu z systemem operacyjnym Android.

### 1) Pierwsza strona - powitanie i wybór lokalizacji
Aplikacja ma opcję automatycznego pobierania lokalizacji, przy pierwszym pobraniu aplikacji na telefon pojawia się okno z zapytaniem o możliwość popierania tych danych z urządzenia.

![screen1](/Pictures/Screenshot_20200207-111223.jpg)

Jeśli użytkownik nie chce podać swojej dokładnej lokalizacji może wybrać miasto z listy. 

![screen2](/Pictures/Screenshot_20200207-111230.jpg)

### 2) Menu
W menu znajdują się 4 opcje: Wschód/Zachód, Kalendarz, Znaki Zodiaku i Fazy Księżyca. Po kliknięciu na daną ikonę aplikacja przechodzi dalej.

![screen3](/Pictures/Screenshot_20200207-111245.jpg)

### 3) Wschód/Zachód
W tej sekcji znajdują się:
- aktualna data
- informacje o przesileniach
- godziny wschodu/górowania/zachodu Słońca
- długość dnia
- możliwość sprawdzenia godzin Słońca dla innej daty (datę wpisuje się w wyznaczonych polach i potwierdza się kliknięciem na duży żółty przycisk)

![screen4](/Pictures/Screenshot_20200207-111325.jpg)

### 4) Kalendarz
Ta sekcja zawiera spis wydarzeń astronomicznych dla każdego miesiąca roku 2019.
Dane do kalendarza są pobierane z określonego pliku .xml umieszczonego na Dysku Google (plik ten może być aktualizowany, do niego wpisuje się wybrane wydarzenia astronomiczne).
Plik pobierany jest, jeśli urządzenie ma dostęp do Internetu, potwierdza to pojawie się ikony pobieranego pliku na górnym pasku urządzenia. 
Pierwsze pobieranie odbywa się przy włączaniu aplikacji, ale istnieje też możliwość ponownego pobrania pliku po naciśnięciu przycisku "Uaktualnij dane".
![screen5](/Pictures/Screenshot_20200207-111350.jpg)
![screen6](/Pictures/Screenshot_20200207-111402.jpg)

### 5) Znaki Zodiaku
W tej sekcji można wybrać swój znak Zodiaku z listy i dowiedzieć się 4 informacji:
- dla jakich dni w roku obowiązuje;  
- krótkiej ciekawostki;
- jak wygląda jego gwiazdozbiór na niebie;
- jak znaleźć gwiazdozbiór na niebie.

![screen7](/Pictures/Screenshot_20200207-111440.jpg)

### 6) Fazy Księżyca
W tej sekcji sprawdza się aktualną fazę księżyca (wyliczaną na podstawie algorytmu). Pojawia się jej nazwa, graficzne przedstawienie oraz krótki opis.
Istnieje możliwość wybrania innej daty.
![screen7](/Pictures/Screenshot_20200207-111448.jpg)
![screen7](/Pictures/Screenshot_20200207-111519.jpg)

## Grafiki
Elementy graficzne takie jak ikony w menu, obrazki faz Księżyca, Słońce zostały wykonane własnoręcznie. Natomiast tło i obrazy gwiazdozbiorów zostały pobrane z Internetu.
