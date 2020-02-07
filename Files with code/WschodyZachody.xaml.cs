using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObserwatorzyGwiazd
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WschodyZachody : ContentPage
	{
		public WschodyZachody ()
		{
            InitializeComponent ();

            KlasaAlgorytmy algorytm = new KlasaAlgorytmy();
            DateTime teraz = DateTime.Now;
            pokazDate(teraz);

            //Przesilenia: letnie i zimowe
            int roznicaPL = algorytm.obliczPrzesilenieL(teraz);
            int roznicaPZ = algorytm.obliczPrzesilenieZ(teraz);
            uzupelnijPrzesilenia(roznicaPL, roznicaPZ);

            if(sprawdzCzasLetni(teraz)==true) // informacja o czasie letnim potrzebna do algorytmu z godzinami Słońca
            {
                Dane.czasLetni = true;
            }
            string[] godzinySlonca = algorytm.liczGodzinySlonca(Dane.dlGeo, Dane.szerGeo, teraz.Year, teraz.Month, teraz.Day); // metoda zwraca 4 różne godziny (wschod, górowanie, zachód i dlugość dnia)
            poleWschodSl.Text = godzinySlonca[0];
            poleGoraSl.Text = godzinySlonca[1];
            poleZachodSl.Text = godzinySlonca[2];
            poleDlDnia.Text = "Długość dnia wynosi: " + godzinySlonca[3] + " godzin.";

        }
        public bool sprawdzCzasLetni(DateTime kiedy)
        {
            bool czyCzasLetni = TimeZone.CurrentTimeZone.IsDaylightSavingTime(kiedy);
            return czyCzasLetni;
        }
        public void pokazDate(DateTime data)
        {
            KlasaAlgorytmy klA = new KlasaAlgorytmy();
            dataDzis.Text = "DZIŚ: " + klA.poprawWyswietlanyFormat(data.Day).ToString() + "." + klA.poprawWyswietlanyFormat(data.Month).ToString() + "." + data.Year.ToString();
        }
        public void uzupelnijPrzesilenia(int roznicaPL, int roznicaPZ)
        {
            if(roznicaPL<0) // oznacza że przesilenie letnie w bieżącym roku już minęło.
            {
                roznicaPL *= -1;
                polePrzesileniaL.Text = roznicaPL.ToString() + " dni za przesileniem letnim.";
            }
            else
                polePrzesileniaL.Text ="DZIEŃ SIĘ WYDŁUŻA. " + roznicaPL.ToString() + " dni do przesilenia letniego.";

            if(roznicaPZ<0) // oznacza, że przesilenie zimowe w bieżącym roku już minęło.
            {
                roznicaPZ *= -1;
                polePrzesileniaZ.Text = roznicaPZ.ToString() + " dni za przesileniem zimowym.";
            }
            else
            {
                if(roznicaPZ<Dane.dniMiedzyPrzesileniami)
                    polePrzesileniaZ.Text = "DZIEŃ SIĘ SKRACA. "+ roznicaPZ.ToString() + " dni do przesilenia zimowego.";
                
                else
                    polePrzesileniaZ.Text = roznicaPZ.ToString() + " dni za przesileniem zimowym.";
            }
        }

        private void SlonceWZ_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(dzienWZ.Text) && !string.IsNullOrWhiteSpace(miesiacWZ.Text) && !string.IsNullOrWhiteSpace(rokWZ.Text))
            {
                int rrrr, mm, dd;
                KlasaAlgorytmy algorytm = new KlasaAlgorytmy();
                DateTime nowaData = new DateTime();
                if (int.TryParse(rokWZ.Text, out rrrr))
                {
                    if(int.TryParse(miesiacWZ.Text, out mm))
                    {
                        if(int.TryParse(dzienWZ.Text, out dd))
                        {
                            nowaData = new DateTime(rrrr,mm,dd);
                        }
                    }
                }

                if (sprawdzCzasLetni(nowaData) == true) // informacja potrzebna do algorytmu
                {
                    Dane.czasLetni = true;
                }
                else
                    Dane.czasLetni = false;
                string[] godzinySlonca = algorytm.liczGodzinySlonca(Dane.dlGeo, Dane.szerGeo, nowaData.Year, nowaData.Month, nowaData.Day);
                poleWschodSl.Text = godzinySlonca[0];
                poleGoraSl.Text = godzinySlonca[1];
                poleZachodSl.Text = godzinySlonca[2];
                poleDlDnia.Text = "Długość dnia wynosi: "+ godzinySlonca[3] + " godzin.";

            }
            else
            {
                DisplayAlert("Uwaga", "Dane nie zostały poprawnie wpisane.", "OK");
            }
        }

    }
}