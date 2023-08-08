using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleInventoryManagementSystem
{
    internal class Inventory
    {
        private List<Product> products;

        public Inventory()
        {
            products = new List<Product>();
        }

        public bool Add(Product product)
        {
            if (product.IsValid())
            {
                var existingProduct = products.FirstOrDefault(p => p.Name == product.Name);

                if (existingProduct != null)
                {
                    existingProduct.Quantity += product.Quantity;
                }
                else
                {
                    products.Add(product);
                }
                return true ;
            }
            else
            {
                return false;
            }
        }

        public List<Product> Display()
        {
            return products;
        }

        public bool Edit(string productName , string newName , decimal newPrice , int newQuantity )
        {
            var existingProduct = products.FirstOrDefault(p => p.Name == productName);
            if (existingProduct != null)
            {
                existingProduct.Name = newName;
                existingProduct.Price =newPrice;
                existingProduct.Quantity = newQuantity;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string productName)
        {
            var existingProduct = products.FirstOrDefault(p => p.Name == productName);
            if (existingProduct != null)
            {
                products.Remove(existingProduct);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Product Search(string productName)
        {
            var existingProduct = products.FirstOrDefault(p => p.Name == productName);
                return existingProduct;
        }
    }
}
