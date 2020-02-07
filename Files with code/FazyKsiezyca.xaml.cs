using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObserwatorzyGwiazd
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FazyKsiezyca : ContentPage
	{
		public FazyKsiezyca ()
		{
			InitializeComponent ();
            KlasaAlgorytmy klAl = new KlasaAlgorytmy();
            OdczytywanieXml oXml = new OdczytywanieXml(Dane.sciezkaPobranegoPliku);  //Ta sciezka została zapisana przy pobieraniu pliku
            DateTime dzis = DateTime.Now;

            // Jeśli się nie uda pobrać pliku z interentu, zostanie użyty zapisany w aplikacji plik
            if(Dane.sciezkaPobranegoPliku==null)
            {
                oXml = new OdczytywanieXml("wydarzeniaUpdate.xml");                  //Plik jest zawarty w projekcie.
            }
                
            string faza = klAl.wyliczFaze(dzis.Day, dzis.Month, dzis.Year);
            nazwaFazy.Text = faza;
            obrazFazy.Source = klAl.dopasujObrazFazy(faza);
            opisFazy.Text = oXml.dopasujOpisFazy(faza);
		}

        private void DataKs_Clicked(object sender, EventArgs e)
        {
            KlasaAlgorytmy klAl = new KlasaAlgorytmy();
            OdczytywanieXml oXml = new OdczytywanieXml(Dane.sciezkaPobranegoPliku);  //Ta sciezka została zapisana przy pobieraniu pliku. 
            if (Dane.sciezkaPobranegoPliku == null)
                oXml = new OdczytywanieXml("wydarzeniaUpdate.xml");                  //Plik jest zawarty w projekcie.

            if (!string.IsNullOrWhiteSpace(dzienKs.Text) && !string.IsNullOrWhiteSpace(miesiacKs.Text) && !string.IsNullOrWhiteSpace(rokKs.Text))
            {
                int rrrr, mm, dd;
                KlasaAlgorytmy algorytm = new KlasaAlgorytmy();
                DateTime nowaData = new DateTime();
                if (int.TryParse(rokKs.Text, out rrrr))
                {
                    if (int.TryParse(miesiacKs.Text, out mm))
                    {
                        if (int.TryParse(dzienKs.Text, out dd))
                        {
                            nowaData = new DateTime(rrrr, mm, dd);
                        }
                    }
                }

                string faza = klAl.wyliczFaze(nowaData.Day, nowaData.Month, nowaData.Year);
                nazwaFazy.Text = faza;
                obrazFazy.Source = klAl.dopasujObrazFazy(faza);
                opisFazy.Text = oXml.dopasujOpisFazy(faza);

            }
            else
            {
                DisplayAlert("Uwaga", "Dane nie zostały poprawnie wpisane.", "OK");
            }
        }
    }
}