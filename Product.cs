using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    internal class Product
    {
        private string Name;
        private double Price;
        private int Quantity;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public double price
        {
            get { return Price; }
            set
            {
                if (value >= 0)
                {
                    Price = value;
                }
                else
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
            }
        }

        public int quantity
        {
            get { return Quantity; }
            set
            {
                if (value >= 0)
                {
                    Quantity = value;
                }
                else
                {
                    throw new ArgumentException("Quantity cannot be negative.");
                }
            }
        }
        public Product(String name, double price, int quantitiy)
        {
              this.name = name;
              this.price = price;
              this.quantity = quantitiy;  
        }



    }
}
