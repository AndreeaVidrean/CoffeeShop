using System;
using System.IO;
using CoffeeShop.Data;

namespace CoffeeShop
{
    public partial class App : Application
    {
        static CoffeeShopDatabase database;

        public static CoffeeShopDatabase Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoffeeShop.db3");
                    database = new CoffeeShopDatabase(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
