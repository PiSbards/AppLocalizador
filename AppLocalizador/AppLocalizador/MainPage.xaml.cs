using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppLocalizador
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        
        async void Button_Clicked(object sender, EventArgs e)
        {
            
            try
            {
                var endereco = ;
                var location = await Geolocation.GetLocationAsync(endereco);
                var locationinfo = new Location(location.Latitude, location.Longitude);
                var options = new MapLaunchOptions { Name = "Meu local" };
                await Map.OpenAsync(locationinfo, options);
            }
            catch (FeatureNotEnabledException fnsEx)
            {
                await DisplayAlert("Falhou", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Falhou", pEx.Message, "OK");
            }
            catch (Exception er)
            {
                await DisplayAlert("Falhou", er.Message, "OK");
            }
        }
    }
}
