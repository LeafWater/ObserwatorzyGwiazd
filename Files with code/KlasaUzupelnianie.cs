using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObserwatorzyGwiazd
{
    class KlasaUzupelnianie
    {
        ImageSource[] obrazyZodiakow = new ImageSource[] { "baran.jpg", "byk.jpg", "bliznieta.jpg", "rak.jpg", "lew.jpg", "panna.jpg", "waga.jpg", "skorpion.jpg",
                "strzelec.jpg", "koziorozec.jpg", "wodnik.jpg", "ryby.jpg" };
        String[] opisyZodiakow = new String[] { "Pierwszy astrologiczny znak zodiaku. Słońce wchodzi w znak Barana w chwili równonocy wiosennej.", "Duży i wyraźny, 17. co do wielkości, gwiazdozbiór zodiakalny. Z Bykiem związane są podstawowe obiekty nieba zimowego: gromady otwarte Plejady i Hiady oraz pozostałość po supernowej – Mgławicy Kraba. Sumeryjczycy nazywali tę konstelację Świetlnym Bykiem, natomiast Egipcjanie czcili ją jako Ozyrysa-Apisa. Grecy łączyli gwiazdozbiór z uwiedzeniem przez Zeusa Europę, córkę fenickiego króla Agenora.  ", "30. co do wielkości, jeden z bardziej charakterystycznych gwiazdozbiorów. Bliźnięta to trzeci gwiazdozbiór zodiakalny. Posiada dwie charakterystyczne, sąsiadujące ze sobą gwiazdy – Kastora i Polluksa. Obszar nieba określany dziś jako konstelacja Bliźniąt, a w szczególności dwie jego najjaśniejsze gwiazdy, prawie we wszystkich kulturach był łączony z lokalnymi mitami. W Egipcie obiekty te identyfikowano z parą kiełkujących ziaren, natomiast w kulturze fenickiej przypisywano im postać pary kozłów. ", "Słońce wchodzi w znak Raka w chwili przesilenia letniego. Gwiazdozbiór przedstawia olbrzymiego raka z ostrymi kleszczami. Rak, podobnie jak wszystkie gwiazdozbiory pasa zodiakalnego, ma związek z mitologią grecką. Jedna z legend mówi, że raka na niebie umieściła Hera, która stała po stronie wszystkich nieprzyjaciół Herkulesa. ", "Najjaśniejszą gwiazdą konstelacji jest Regulus.Gwiazdozbiór przedstawia jednego z potworów, od których Herkules uwolnił ludzi. Egipcjanie natomiast wiązali gwiazdozbiór Lwa z nadejściem lata, kiedy to Lew jest wieczorem najwyżej nad horyzontem. ", "Rozciąga się po obu stronach równika niebieskiego, między Lwem i Wagą. Jest to największy gwiazdozbiór zodiakalny i drugi co do wielkości gwiazdozbiór na niebie (ustępuje wielkością jedynie Hydrze). W Pannie znajduje się najwięcej galaktyk na całym niebie.", "Mało wyraźny, 29. co do wielkości, gwiazdozbiór zodiakalny, znany już w starożytności. Słońce wchodzi w znak Wagi w chwili równonocy jesiennej. ", "33. co do wielkości gwiazdozbiór nieba, jedna z konstelacji zodiakalnych. Skorpion to jeden z najstarszych znanych gwiazdozbiorów. Pięć tysięcy lat temu rozpoznawany był przez cywilizację Sumerów. Już wtedy był to Gir-Tab (Skorpion). Historia Skorpiona jest ściśle związana z historią Oriona, który był potężnym myśliwym.", "konstelacja zodiakalna, piętnasty co do wielkości gwiazdozbiór na sferze niebieskiej, znany już w starożytności. Najwcześniejsze informacje o grupie gwiazd znanej dzisiaj jako Strzelec pochodzą od Sumerów, którzy identyfikowali ją z Nergalem. Był to bóg zsyłający zarazę, który władał światem podziemnym.", "Słońce wchodzi w znak Koziorożca w chwili przesilenia zimowego. To jeden z gwiazdozbiorów zodiakalnych, 40. co do wielkości, znany już w starożytności. Jest dziesiątym i zarazem najmniejszym spośród gwiazdozbiorów zodiakalnych. ", "To dziesiąty co do wielkości gwiazdozbiór sąsiadujący z Wielorybem, Rybami, Delfinem i Rybą Południową. Wodnik to jeden z najstarszych (w sensie antropologicznym) gwiazdozbiorów. Konstelacja znana była już w Babilonii i starożytnym Egipcie.", "Ryby to duży, czternasty co do wielkości gwiazdozbiór zodiakalny. " };
        String[] opisyDodatkowe = new String[] { "Baran jest niewielkim, ale wyraźnym gwiazdozbiorem pasa zodiakalnego. Leży na północnej półkuli nieba, w Polsce widoczny jesienią i zimą. Słońce przebywa w konstelacji Barana między końcem kwietnia a połową maja.", "Gwiazdozbiór zodiakalny nieba północnego, leżący w pobliżu równika niebieskiego. Liczba gwiazd dostrzegalnych nieuzbrojonym okiem wynosi około 125. W Polsce widoczny od jesieni do wiosny. ", "Słońce przebywa na tle tego gwiazdozbioru od 21 czerwca do 20 lipca. W Polsce widoczny od jesieni do wiosny, a w szczególności w grudniu i styczniu, kiedy góruje około północy. Liczba gwiazd dostrzegalnych nieuzbrojonym okiem: około 70.", "Konstelacja widoczna na północnym niebie. W Polsce widoczna od zimy do wiosny. Mimo niezbyt jasnych gwiazd konstelację Raka odnajdziemy łatwo, gdyż mieści się w środku równobocznego trójkąta, utworzonego przez gwiazdy: Polluks, Regulus i Procjon. Liczba gwiazd widocznych nieuzbrojonym okiem: około 60.", "Słońce wędruje na tle tego gwiazdozbioru od 10 sierpnia do 16 września. Liczba gwiazd widoczna nieuzbrojonym okiem: około 70. W Polsce widoczny wiosną.", "Liczba gwiazd dostrzegalnych nieuzbrojonym okiem: około 95. W Polsce widoczny wiosną. Słońce przechodzi przez konstelację we wrześniu i w październiku.", " Znajduje się na południowej półkuli nieba. Liczba gwiazd dostrzegalnych nieuzbrojonym okiem wynosi około 50. W Polsce widoczny wiosną i latem.", "Znajduje się na południowej półkuli nieba, jednak pod koniec lata z terenów Polski da się niekiedy dojrzeć tuż ponad horyzontem kilka gwiazd tego gwiazdozbioru, między innymi β, σ, π i α Scorpii (Antares). W całości widoczny na południe od równoleżnika 45°N. Liczba gwiazd dostrzegalnych nieuzbrojonym okiem wynosi około 100. Najjaśniejszą gwiazdą tej konstelacji jest Antares.", "Położony na południowej półkuli nieba, stosunkowo blisko równika niebieskiego. W Polsce gwiazdozbiór częściowo widoczny latem, w całości widoczny na południe od równoleżnika 45°N. Liczba gwiazd dostrzegalnych nieuzbrojonym okiem: około 115.", "Położony jest na południowej półkuli nieba. Liczba gwiazd dostrzegalnych nieuzbrojonym okiem wynosi około 50. W Polsce widoczny latem.", "Wodnik należy do rozległych, ale niezbyt wyraźnych gwiazdozbiorów pasa zodiakalnego. Położony na południe od równika niebieskiego. Liczba gwiazd dostrzegalnych nieuzbrojonym okiem: około 90. W Polsce widoczny jesienią, a Słońce przechodzi przez konstelację Wodnika w lutym i marcu.", "To  gwiazdozbiór zodiakalny nieba północnego, znajdujący się w pobliżu równika niebieskiego. W Polsce widoczny jesienią. Liczba gwiazd widocznych nieuzbrojonym okiem: około 75." };
        String[] nazwy = new String[] { "Baran", "Byk", "Bliźnięta", "Rak", "Lew", "Panna", "Waga", "Skorpion", "Strzelec", "Koziorożec", "Wodnik", "Ryby" };
        String[] datyZodiakow = new String[] {"(21 marca – 19 kwietnia)","(20 kwietnia – 20 maja)","(21 maja – 20 czerwca)", "(21 czerwca – 22 lipca)", "(23 lipca – 22 sierpnia)", "(23 sierpnia – 22 września)", "(23 września – 22 października)", "(23 października – 21 listopada)", "(22 listopada – 21 grudnia)", "(22 grudnia – 19 stycznia)", "(20 stycznia – 18 lutego)", "(19 lutego – 20 marca)" };

        public ImageSource dopasujObraz(int ktoryZodiak)
        {
            return obrazyZodiakow[ktoryZodiak];
        }
        public String dopasujOpisGl(int ktoryZodiak)
        {
            return opisyZodiakow[ktoryZodiak];
        }
        public String dopasujOpisDodatk(int ktoryZodiak)
        {
            return opisyDodatkowe[ktoryZodiak];
        }
        public String dopasujNazweIDate(int ktoryZodiak)
        {
            return nazwy[ktoryZodiak]+" "+datyZodiakow[ktoryZodiak];
        }
        public String dopasujNazwe(int ktoryZodiak)
        {
            return nazwy[ktoryZodiak];
        }
   
    }
}
