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
            RequestPermissionsAsync();

            MainPage = new AppShell();
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
                await MainPage.DisplayAlert("Permission Denied", "Location permission is required to use this feature.", "OK");
            }
        }
    }
}
