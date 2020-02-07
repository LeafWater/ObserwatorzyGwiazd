using Plugin.DownloadManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ObserwatorzyGwiazd
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Pobranie pliku z internetu, by wczytać dane do Kalendarza i Faz Księżyca
            CrossDownloadManager.Current.CollectionChanged += (sender, e) =>
                System.Diagnostics.Debug.WriteLine(
                    "[DownloadManager]" + e.Action +
                    " -> New items: " + (e.NewItems?.Count ?? 0) +
                    " at " + e.NewStartingIndex +
                    " || Old itmes: " + (e.OldItems?.Count ?? 0) +
                    " at " + e.OldStartingIndex
                    );
            PobraniePliku pp = new PobraniePliku();
            var Url = "https://drive.google.com/uc?export=download&id=1AiSuqTVxtzdK6JI6fV9pRFXJnt1Lxm5G";  //link z którego automatycznie pobiera się plik z danymi o astronomicznych wydarzeniach
            pp.DownloadFile(Url);                                                                          //pobieranie pliku z linku 
        }

        async private void WschZach_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WschodyZachody());
        }

        async private void Kalendarz_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Kalendarz());
        }

        async private void Zodiak_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Zodiak());
        }

        async private void FazyKsiezyca_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FazyKsiezyca());
        }
    }
}
