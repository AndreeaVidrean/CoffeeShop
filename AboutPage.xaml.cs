using CoffeeShop.Models;

namespace CoffeeShop
{
    public partial class AboutPage : ContentPage
    {
        public Coffee CoffeeItem { get; set; }

        // Constructor f�r� parametri (necesar pentru framework)
        public AboutPage()
        {
            InitializeComponent();

            // Creeaz� un obiect gol pentru BindingContext, dac� este necesar
            CoffeeItem = new Coffee
            {
                Name = string.Empty,
                Description = string.Empty,
                Price = 0,
                CreatedDate = DateTime.Now
            };

            BindingContext = CoffeeItem;
        }

        // Constructor cu parametri (pentru utilizarea manual�)
        public AboutPage(Coffee coffee)
        {
            InitializeComponent();
            CoffeeItem = coffee;
            BindingContext = CoffeeItem;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            // Salv�m articolul �n baza de date
            await App.Database.SaveCoffeeAsync(CoffeeItem);

            // Navig�m �napoi la pagina anterioar�
            await Navigation.PopAsync();
        }
    }
}
