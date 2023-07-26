using System;
using System.Collections.Generic;

namespace Simple_Inventory_Management_System
{
    internal class Inventory
    {
        private List<Product> products;

        public Inventory()
        {
            products = new List<Product>();
        }

        public void add(Product product)
        {
            if (product.isValid())
            {
                var _existsInList = 0;
                foreach (Product p in products)
                {
                    if ((p.name) == (product.name))
                    {
                        _existsInList = 1;
                        p.quantity += product.quantity;
                        break;
                    }
                }
                if (_existsInList == 0)
                {
                    products.Add(product);
                }
            }
            else Console.WriteLine("Product not valid :( ");
        }//add

        public void display()
        {
            foreach (Product p in products)
            {
                Console.WriteLine("Name: " + p.name + " || Price: " + p.price + " || Quantity: " + p.quantity);
            }
        }//display

        public void edit(string product_Name)
        {
            var existingProductIndex = products.FindIndex(p => p.name == product_Name);
            if (existingProductIndex != -1)
            {
                Product existingProduct = products[existingProductIndex];
                Console.WriteLine("Enter the new name: ");
                string new_Name = Console.ReadLine();
                Console.WriteLine("Enter the new price: ");
                double new_Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new quantity: ");
                int new_quantity = int.Parse(Console.ReadLine());

                
                existingProduct.name = new_Name;
                existingProduct.price = new_Price;
                existingProduct.quantity = new_quantity;

                Console.WriteLine("Product is edited :)");
            }
            else
            {
                Console.WriteLine("Item not exists !!");
            }
        }//edit


        public void delete(String product_Name)
        {
            var existingProductIndex = products.FindIndex(p => p.name == product_Name);
            if (existingProductIndex != -1)
            {
                products.RemoveAt(existingProductIndex);
                Console.WriteLine("Product is deleted :)");
            }
            else
            {
                Console.WriteLine("Item not exists !!");
            }
        }//delete

        public void search(string product_Name)
        {
            var existingProduct = products.Find(p => p.name == product_Name);
            if (existingProduct != null)
            {
                Console.WriteLine("Name: " + existingProduct.name + " || Price: " + existingProduct.price + " || Quantity: " + existingProduct.quantity);
            }
            else
            {
                Console.WriteLine("Item not exists !! ");
            }
        } //search
    }//class
}// name space
