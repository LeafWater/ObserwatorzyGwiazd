using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace ObserwatorzyGwiazd
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Wstep : ContentPage
	{
		public Wstep ()
		{
			InitializeComponent ();
		}

        async private void PickerMiasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            if(picker.SelectedItem.ToString()=="Katowice")         // W przypadku, gdy użytkownik nie chce pozwolić na pobranie swojej dokładnej lokalizacji, może wybrać jedną z podanych lokalizacji.
            {
                Dane.szerGeo = 50;
                Dane.dlGeo = 19;
            }
            else if(picker.SelectedItem.ToString() == "Warszawa")
            {
                Dane.szerGeo = 52;
                Dane.dlGeo = 21;
            }
            else if(picker.SelectedItem.ToString() == "Gdańsk")
            {
                Dane.szerGeo = 54;
                Dane.dlGeo = 18;
            }
            await Navigation.PushAsync(new MainPage());
        }

        async private void PobierzLokalizacje_Clicked(object sender, EventArgs e)
        {
            // pobranie lokalizacji
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    Dane.szerGeo = position.Latitude;
                    Dane.dlGeo = position.Longitude;
                    await Navigation.PushAsync(new MainPage());
                }
                else
                    await DisplayAlert("Uwaga!", "Brak danych o lokalizacji", "OK");

                if(!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                    await DisplayAlert("Uwaga!", "Brak urządzenia z lokalizacją.", "OK");
                else
                {
                    position = await locator.GetPositionAsync(TimeSpan.FromSeconds(5));
                    Dane.szerGeo = position.Latitude;
                    Dane.dlGeo = position.Longitude;
                    await Navigation.PushAsync(new MainPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Uwaga!", "Błąd z GPS: " + ex.Message, "OK");
            }           
        }
    }
}