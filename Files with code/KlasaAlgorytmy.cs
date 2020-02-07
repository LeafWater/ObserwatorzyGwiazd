using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Xml;

namespace ObserwatorzyGwiazd
{
    class KlasaAlgorytmy
    {
        private static Page page;

        // metoda licząca dni od/do przesilenia letniego w 2019 roku
        public int obliczPrzesilenieL(DateTime data)
        {
            int wynik;
            DateTime przesilenieL = new DateTime(2019,6,21);
            TimeSpan roznica = przesilenieL - data;
            wynik = roznica.Days;
            return wynik;
        }
        // metoda licząca dni od/do przesilenia zimowego w 2019 roku
        public int obliczPrzesilenieZ(DateTime data)
        {
            int wynik;
            DateTime przesilenieZ = new DateTime(2019, 12, 22);
            DateTime przesilenieL = new DateTime(2019, 6, 21);
            TimeSpan roznica = przesilenieZ - data;
            TimeSpan roznica2 = przesilenieZ - przesilenieL;
            Dane.dniMiedzyPrzesileniami = roznica2.Days;
            wynik = roznica.Days;
            return wynik;
        }

        //metoda licząca godzinę wschodu/górowania/zachodu Słońca
        public string[] liczGodzinySlonca(double dl, double szer, int rok, int miesiac, int dzien)
        {
            string[] wyniki = new string[4];
            double N3 = Math.PI / 180;
            double O3 = 57.29577951;
            int D5 = rok;
            int D6 = miesiac;
            int D7 = dzien;
            int E6, E7, L5, L6;
            double L7, M3, M4, M5, M6, M7, M8, M9, O5, N5, N4, O4, N6, N7, N9, N10, N11, M11,
                N12, N15, O15, M13, O16, N16, P15, P17, P18, R18, R19, Q17, Q18;

            if (D6 <= 2)
            {
                E6 = D6 + 12;
                E7 = D5 - 1;
            }
            else
            {
                E6 = D6;
                E7 = D5;
            }
            L5 = (int)(D5 / 100);
            L6 = 2 - L5 + (int)(L5 / 4);
            L7 = (int)(365.25 * (E7 + 4716)) + (int)(30.6001 * (E6 + 1)) + D7 + L6 - 1524.5;
            M3 = (L7 - 2451545) / 36525;
            M4 = 280.46646 + 36000.76983 * M3 + 0.0003032 * M3 * M3;
            M5 = 357.52911 + 35999.05029 * M3 - 0.0001537 * M3 * M3;
            N5 = M5 / 360;
            O5 = (N5 - (int)N5) * 360;
            M6 = (1.914602 - 0.004817 * M3 - 0.000014 * M3 * M3) * Math.Sin(O5 * N3);
            M7 = (0.019993 - 0.000101 * M3) * Math.Sin(2 * O5 * N3);
            M8 = 0.000289 * Math.Sin(3 * O5 * N3);
            M9 = M6 + M7 + M8;
            N4 = M4 / 360;
            O4 = (N4 - (int)N4) * 360;
            N6 = O4 + M9;
            N7 = 125.04 - 1934.136 * M3;

            if (N7 < 0)
                N9 = N7 + 360;
            else
                N9 = N7;

            N10 = N6 - 0.00569 - 0.00478 * Math.Sin(N9 * N3);
            M11 = 23.43930278 - 0.0130042 * M3 - 0.000000163 * M3 * M3;
            N11 = Math.Sin(M11 * N3) * Math.Sin(N10 * N3);
            N12 = Math.Asin(N11) * 180 / Math.PI;
            N15 = dl / 15;
            O15 = szer;
            M13 = (7.7 * Math.Sin((O4 + 78) * N3) - 9.5 * Math.Sin(2 * O4 * N3)) / 60;
            O16 = Math.Cos(N12 * N3) * Math.Cos(O15 * N3);
            N16 = (-0.01483) - Math.Sin(N12 * N3) * Math.Sin(O15 * N3);
            P15 = 2 * (Math.Acos(N16 / O16) * O3) / 15;
            if (Dane.czasLetni == true)
                M13 += 1;

            P17 = (13 - N15 + M13 - (P15 / 2));     // godzina wschodu Słońca
            P18 = (int)((P17 - (int)(P17)) * 60);   // minuty wschodu Słońca
            R18 = 13 - N15 + M13;                    // godzina górowania Słońca
            R19 = (int)((R18 - (int)(R18)) * 60);   //minuty górowania Słońca
            Q17 = 13 - N15 + M13 + (P15 / 2);        // godzina zachodu Słońca
            Q18 = (int)((Q17 - (int)(Q17)) * 60);   // minuty zachodu Słońca

            P17 = Math.Floor(P17);
            R18 = Math.Floor(R18);
            Q17 = Math.Floor(Q17);
            
            wyniki[0] = poprawWyswietlanyFormat(P17) + ":" + poprawWyswietlanyFormat(P18);      //wschód
            wyniki[1] = poprawWyswietlanyFormat(R18) + ":" + poprawWyswietlanyFormat(R19);      //górowanie
            wyniki[2] = poprawWyswietlanyFormat(Q17) + ":" + poprawWyswietlanyFormat(Q18);      //zachód                 

            //obliczenie dl dnia
            TimeSpan dlDnia = DateTime.Parse(wyniki[2]).Subtract(DateTime.Parse(wyniki[0]));
            wyniki[3] = dlDnia.ToString(@"hh\:mm");

            return wyniki;
        }

        // metoda poprawiająca wygląd wyświetlanych liczb; Żeby na przykład zamiast wyświetlać "1" wyświetlało "01"
        public string poprawWyswietlanyFormat(double liczba)
        {
            if (liczba <= 9)
            {
                return "0" + liczba.ToString();
            }
            else
                return liczba.ToString();
        }

        // wyliczenie fazy księżyca
        public string wyliczFaze(int dzien, int miesiac, int rok)
        {
            string fazaKsiezyca="";

            if (miesiac == 1 || miesiac == 2)
            {
                rok -= 1;
                miesiac += 12;
            } 
            int A = rok / 100;
            int B = A / 4;
            int C = 2 - A + B;
            double E = (365.25 * (rok + 4716)); E = (int)E;
            double F = 30.6001 * (miesiac + 1); F = (int)F;
            double julianDay = C + dzien + E + F - 1524.5;

            double daySinceNew = julianDay - 2451549.5;
            double cykleKsiezyca = daySinceNew / 29.53;
            double faza = (cykleKsiezyca - (int)cykleKsiezyca) * 29.53;

            if (faza > 30 || faza < -1)
                page.DisplayAlert("Błąd", "Sprawdź, czy dane zostały poprawnie wpisane.", "OK");
            else if (faza <= 6.5 && faza >= 3)
                fazaKsiezyca = "Sierp Przybywający";
            else if (faza < 10 && faza > 6.5)
                fazaKsiezyca = "Pierwsza Kwadra";
            else if (faza <= 14 && faza >= 10)
                fazaKsiezyca = "Księżyc Garbaty Przybywający";
            else if (faza > 14 && faza < 16)
                fazaKsiezyca = "Pełnia";
            else if (faza >= 16 && faza < 20.5)
                fazaKsiezyca = "Księżyc Garbaty Ubywający";
            else if (faza >= 20.5 && faza < 23)
                fazaKsiezyca = "Ostatnia Kwadra";
            else if (faza >= 23 && faza <= 28)
                fazaKsiezyca = "Sierp Ubywający";
            else
                fazaKsiezyca = "Nów";

            return fazaKsiezyca;
        }

        public ImageSource dopasujObrazFazy(String nazwaFazy)
        {
            if (nazwaFazy == "Nów")
                return "now.jpg";
            else if (nazwaFazy == "Sierp Przybywający")
                return "sierp_przybywajacy.jpg";
            else if (nazwaFazy == "Pierwsza Kwadra")
                return "pierwsza_kwadra.jpg";
            else if (nazwaFazy == "Księżyc Garbaty Przybywający")
                return "przybywajacy_ksiezyc_garbaty.jpg";
            else if (nazwaFazy == "Pełnia")
                return "pelnia.jpg";
            else if (nazwaFazy == "Księżyc Garbaty Ubywający")
                return "ubywajacy_ksiezyc_garbaty.jpg";
            else if (nazwaFazy == "Ostatnia Kwadra")
                return "ostatnia_kwadra.jpg";
            else if (nazwaFazy == "Sierp Ubywający")
                return "sierp_ubywajacy.jpg";
            else
                return "";
        }

    }
}
