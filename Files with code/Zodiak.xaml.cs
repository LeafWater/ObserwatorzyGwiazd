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
	public partial class Zodiak : ContentPage
	{
		public Zodiak ()
		{
			InitializeComponent ();
            zodiakWiecej.IsEnabled = false;
		}

        private void PickerZodiak_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            KlasaUzupelnianie zodiak = new KlasaUzupelnianie();
           
            int ktoryZodiak = picker.SelectedIndex;         // 0 - baran; 1 - byk; 2 - bliźnięta...
            Dane.ktoryZodiak = ktoryZodiak;                 // Informacja przekazana do danych aplikacji, gdyż jest potrzebna w zdarzeniu "ZodiakWiecej_Clicked".
            obrazZodiak.Source = zodiak.dopasujObraz(ktoryZodiak);
            opisZodiak.Text = zodiak.dopasujOpisGl(ktoryZodiak);
            nazwaZodiak.Text = zodiak.dopasujNazweIDate(ktoryZodiak).ToUpper();

            zodiakWiecej.IsEnabled = true;                               // Przycisk dotyczący gwiazdozbioru staje się dostępy.
            opisZodiak.Text = zodiak.dopasujOpisGl(Dane.ktoryZodiak);    // Żeby zawsze po ponownym wybraniu Zodiaku przycisk wracał do początkowej wersji tekstu.
            zodiakWiecej.Text = "Kliknij, aby dowiedzieć się, jak znaleźć gwiazdozbiór.";

        }

        private void ZodiakWiecej_Clicked(object sender, EventArgs e)
        {
            Button przycisk = sender as Button;
            KlasaUzupelnianie zodiak = new KlasaUzupelnianie();

            if(Dane.trybDodatkowy==false)
            {
                opisZodiak.Text = zodiak.dopasujOpisDodatk(Dane.ktoryZodiak); // Zmiana opisu głównego na opis dodatkowy.
                zodiakWiecej.Text = "Pokaż z powrotem opis znaku " + zodiak.dopasujNazwe(Dane.ktoryZodiak)+".";
                Dane.trybDodatkowy = true;
            }
            else
            {
                opisZodiak.Text = zodiak.dopasujOpisGl(Dane.ktoryZodiak);    // Zmiana opisu dodatkowego na opis główny.
                zodiakWiecej.Text = "Kliknij, aby dowiedzieć się, jak znaleźć gwiazdozbiór.";
                Dane.trybDodatkowy = false;
            }
            

        }
    }
}