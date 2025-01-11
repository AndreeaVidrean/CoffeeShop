using CoffeeShop.Models;

namespace CoffeeShop
{
    public partial class AddCoffeePage : ContentPage
    {
        public Coffee CoffeeItem { get; set; }

        // Constructor pentru un produs nou
        public AddCoffeePage()
        {
            InitializeComponent();

            CoffeeItem = new Coffee
            {
                Name = string.Empty,
                Description = string.Empty,
                Price = 0,
                CreatedDate = DateTime.Now
            };

            BindingContext = CoffeeItem;
        }

        // Constructor pentru editarea unui produs existent
        public AddCoffeePage(Coffee coffee)
        {
            InitializeComponent();

            CoffeeItem = coffee;
            BindingContext = CoffeeItem;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            // Salveazã produsul în baza de date
            await App.Database.SaveCoffeeAsync(CoffeeItem);

            // Navigheazã înapoi la pagina Meniu
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            // ?terge produsul din baza de date
            await App.Database.DeleteCoffeeAsync(CoffeeItem);

            // Navigheazã înapoi la pagina Meniu
            await Navigation.PopAsync();
        }
    }
}
