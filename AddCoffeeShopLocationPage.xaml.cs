using CoffeeShop.Models;

namespace CoffeeShop
{
    public partial class AddCoffeeShopLocationPage : ContentPage
    {
        public CoffeeShopLocation Location { get; set; }

        public AddCoffeeShopLocationPage()
        {
            InitializeComponent();
            Location = new CoffeeShopLocation();
            BindingContext = Location;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            await App.Database.SaveCoffeeShopLocationAsync(Location);
            await Navigation.PopAsync();
        }
    }
}
