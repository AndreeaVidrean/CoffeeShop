using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShop.Models;

namespace CoffeeShop.Data
{
    public class CoffeeShopDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public CoffeeShopDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            // Crearea tabelelor
            _database.CreateTableAsync<CoffeeShopLocation>().Wait();
            _database.CreateTableAsync<Coffee>().Wait();
        }



        public Task<List<CoffeeShopLocation>> GetCoffeeShopLocationsAsync()
        {
            return _database.Table<CoffeeShopLocation>().ToListAsync();
        }

        // Salvează o locație CoffeeShop
        public Task<int> SaveCoffeeShopLocationAsync(CoffeeShopLocation location)
        {
            if (location.ID != 0)
            {
                return _database.UpdateAsync(location);
            }
            else
            {
                return _database.InsertAsync(location);
            }
        }

        // Șterge o locație CoffeeShop
        public Task<int> DeleteCoffeeShopLocationAsync(CoffeeShopLocation location)
        {
            return _database.DeleteAsync(location);
        }
    



        // Obține toate produsele
        public Task<List<Coffee>> GetCoffeesAsync()
        {
            return _database.Table<Coffee>().ToListAsync();
        }

        // Obține un produs după ID
        public Task<Coffee> GetCoffeeAsync(int id)
        {
            return _database.Table<Coffee>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        // Salvează un produs (inserare sau actualizare)
        public Task<int> SaveCoffeeAsync(Coffee coffee)
        {
            if (coffee.ID != 0)
            {
                return _database.UpdateAsync(coffee);
            }
            else
            {
                return _database.InsertAsync(coffee);
            }
        }

        // Șterge un produs
        public Task<int> DeleteCoffeeAsync(Coffee coffee)
        {
            return _database.DeleteAsync(coffee);
        }
        public async Task<List<Coffee>> GetCoffeesForLocationAsync(int locationId)
        {
            return await _database.Table<Coffee>()
                                  .Where(c => c.CoffeeShopLocationID == locationId)
                                  .ToListAsync();
        }

        


    }
}
