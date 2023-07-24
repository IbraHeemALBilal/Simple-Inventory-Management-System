using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    internal class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public Product(String name, double price, int quantitiy)
        {
              this.name = name;
              this.price = price;
              this.quantity = quantitiy;  
        }



    }
}
