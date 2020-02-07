using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
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
	public partial class Kalendarz : ContentPage
	{

		public Kalendarz ()
		{
  			InitializeComponent ();
		}

        private void PickerKalendarz_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            KlasaUzupelnianie klU = new KlasaUzupelnianie();
            OdczytywanieXml oXml = new OdczytywanieXml(Dane.sciezkaPobranegoPliku);  //Ta sciezka została zapisana przy pobieraniu pliku (MainActivity.cs)

            if(Dane.sciezkaPobranegoPliku==null)                                     //Jesli nie uda się pobrać pliku z internetu.
            {
                oXml = new OdczytywanieXml("wydarzeniaUpdate.xml");
            }

            String[] wydarzeniaDane = oXml.uzupelnijWydarzenia((picker.SelectedIndex + 1).ToString()); //"+1" żeby indeks miesiąca odpowiadał jemu rzeczywistemu numerowi
            poleWydarzenMiasto.Text = wydarzeniaDane[0];  
            poleWydarzenNazwa.Text = wydarzeniaDane[1];
            poleWydarzenData.Text = wydarzeniaDane[2];

            miesiac.Text = picker.SelectedItem.ToString();
        }

        private void MiesiacWczesniej_Clicked(object sender, EventArgs e)
        {
            Picker pK = pickerKalendarz;
            if(pK.SelectedIndex>0)
                pK.SelectedIndex -= 1;
        }

        private void MiesiacDalej_Clicked(object sender, EventArgs e)
        {
            Picker pK = pickerKalendarz;
            if (pK.SelectedIndex < 11)
                pK.SelectedIndex += 1;
        }

        private void DajDane_Clicked(object sender, EventArgs e)  // przycisk pobierający dane z pliku (jakby użytkownik chciał je uaktualnić bez uruchamiania ponownie aplikacji
        {
            PobraniePliku pp = new PobraniePliku();
            var Url = "https://drive.google.com/uc?export=download&id=1AiSuqTVxtzdK6JI6fV9pRFXJnt1Lxm5G";  //link z którego automatycznie pobiera się plik z danymi o astronomicznych wydarzeniach
            pp.DownloadFile(Url);   //pobieranie pliku z linku     
        }
   
    }
}