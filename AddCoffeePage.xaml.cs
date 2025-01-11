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
            // Salveaz� produsul �n baza de date
            await App.Database.SaveCoffeeAsync(CoffeeItem);

            // Navigheaz� �napoi la pagina Meniu
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            // ?terge produsul din baza de date
            await App.Database.DeleteCoffeeAsync(CoffeeItem);

            // Navigheaz� �napoi la pagina Meniu
            await Navigation.PopAsync();
        }
    }
}
