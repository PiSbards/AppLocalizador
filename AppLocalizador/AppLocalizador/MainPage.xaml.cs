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
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                { DesiredAccuracy = GeolocationAccuracy.Best });
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    var geocodeAddress =
                            $"AdminArea:{txtUF.Text}\n" +
                            $"CountryName:{txtPais.Text}\n" +
                            $"Locality:{txtCidade.Text}\n" +
                            $"SubLocality:{txtLocal.Text}\n";

                    await Map.OpenAsync(location.Latitude, location.Longitude, new MapLaunchOptions { Name = geocodeAddress });

                }
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
