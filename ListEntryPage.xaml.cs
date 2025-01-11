using CoffeeShop.Models;

namespace CoffeeShop
{
    public partial class ListEntryPage : ContentPage
    {
        public ListEntryPage()
        {
            InitializeComponent();
            coffeeListView.ItemsSource = App.Database.GetCoffeesAsync().Result;
        }

        async void OnCoffeeAddedClicked(object sender, EventArgs e)
        {
            // Navigheazã la pagina AddCoffeePage
            await Navigation.PushAsync(new AddCoffeePage());
        }


        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Coffee selectedCoffee)
            {
                await Navigation.PushAsync(new AboutPage(selectedCoffee));
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            coffeeListView.ItemsSource = await App.Database.GetCoffeesAsync();
        }

    }
}
