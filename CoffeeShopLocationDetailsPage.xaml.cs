using CoffeeShop.Models;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace CoffeeShop
{
    public partial class CoffeeShopLocationDetailsPage : ContentPage
    {
        public CoffeeShopLocationDetailsPage(CoffeeShopLocation location)
        {
            InitializeComponent(); // Inițializează componentele definite în XAML
            RequestPermissionsAsync();
            BindingContext = location;
        }

        private async Task RequestPermissionsAsync()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission Denied", "Location permission is required to use this feature.", "OK");
            }
        }

        async void OnShowMapButtonClicked(object sender, EventArgs e)
        {
            var location = BindingContext as CoffeeShopLocation;
            if (location == null) return;

            var locations = await Geocoding.GetLocationsAsync(location.Address);
            var shopLocation = locations?.FirstOrDefault();

            if (shopLocation != null)
            {
                await Map.OpenAsync(shopLocation, new MapLaunchOptions { Name = location.Name });
            }
            else
            {
                await DisplayAlert("Error", "Location not found. Please check the address.", "OK");
            }
        }

        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            var location = BindingContext as CoffeeShopLocation;
            if (location == null) return;

            var locations = await Geocoding.GetLocationsAsync(location.Address);
            var shopLocation = locations?.FirstOrDefault();

            if (shopLocation != null)
            {
                await Map.OpenAsync(shopLocation, new MapLaunchOptions
                {
                    Name = location.Name,
                    NavigationMode = NavigationMode.Driving
                });
            }
            else
            {
                await DisplayAlert("Error", "Location not found. Please check the address.", "OK");
            }
        }
    }
}
