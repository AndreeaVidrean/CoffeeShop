using CoffeeShop.Models;

namespace CoffeeShop
{
    public partial class MenuItemPage : ContentPage
    {
        public MenuItemPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Populeazã lista produselor din baza de date
            menuListView.ItemsSource = await App.Database.GetCoffeesAsync();
        }

        async void OnAddProductClicked(object sender, EventArgs e)
        {
            // Navigheazã la pagina pentru adãugarea unui produs
            await Navigation.PushAsync(new AddCoffeePage());
        }

        async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Coffee selectedCoffee)
            {
                // Navigheazã la pagina pentru editarea produsului selectat
                await Navigation.PushAsync(new AddCoffeePage(selectedCoffee));
            }
        }
    }
}
