using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleInventoryManagementSystem
{
    internal class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public bool IsValid()
        {
            return Quantity > 0 && Price > 0 && !string.IsNullOrEmpty(Name);
        }
    }
}
