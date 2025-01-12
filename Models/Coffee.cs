using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace CoffeeShop.Models
{
    public class Coffee
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CoffeeShopLocationID { get; set; }
    }
}
