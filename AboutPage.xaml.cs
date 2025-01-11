using CoffeeShop.Models;

namespace CoffeeShop
{
    public partial class AboutPage : ContentPage
    {
        public Coffee CoffeeItem { get; set; }

        // Constructor fãrã parametri (necesar pentru framework)
        public AboutPage()
        {
            InitializeComponent();

            // Creeazã un obiect gol pentru BindingContext, dacã este necesar
            CoffeeItem = new Coffee
            {
                Name = string.Empty,
                Description = string.Empty,
                Price = 0,
                CreatedDate = DateTime.Now
            };

            BindingContext = CoffeeItem;
        }

        // Constructor cu parametri (pentru utilizarea manualã)
        public AboutPage(Coffee coffee)
        {
            InitializeComponent();
            CoffeeItem = coffee;
            BindingContext = CoffeeItem;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            // Salvãm articolul în baza de date
            await App.Database.SaveCoffeeAsync(CoffeeItem);

            // Navigãm înapoi la pagina anterioarã
            await Navigation.PopAsync();
        }
    }
}
