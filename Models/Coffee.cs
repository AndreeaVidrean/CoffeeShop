using System;
using System.Collections.Generic;
using SQLite;

namespace CoffeeShop.Models
{
    public class Coffee
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } // Identificator unic

        [MaxLength(250), Unique]
        public string Name { get; set; } // Numele produsului

        public string Description { get; set; } // Descrierea produsului

        public decimal Price { get; set; } // Prețul produsului

        public DateTime CreatedDate { get; set; } // Data adăugării
    }
}
