using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class CoffeeShopLocation
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } // ID unic

        [MaxLength(250), Unique]
        public string Name { get; set; } // Numele locației CoffeeShop-ului

        public string Address { get; set; } // Adresa CoffeeShop-ului

        public string LocationDetails => $"{Name} - {Address}"; // Detalii locație
    }
}