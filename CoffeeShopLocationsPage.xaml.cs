using CoffeeShop.Models;

namespace CoffeeShop
{
    public partial class CoffeeShopLocationsPage : ContentPage
    {
        public CoffeeShopLocationsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            locationsListView.ItemsSource = await App.Database.GetCoffeeShopLocationsAsync();
        }

        async void OnAddLocationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCoffeeShopLocationPage());
        }

        async void OnLocationSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is CoffeeShopLocation selectedLocation)
            {
                await Navigation.PushAsync(new CoffeeShopLocationDetailsPage(selectedLocation));
            }
        }
    }
}
