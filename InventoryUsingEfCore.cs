using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class InventoryUsingEfCore : IInventoryManagment
    {
        private readonly InventoryDbContext _dbContext;

        public InventoryUsingEfCore()
        {
            _dbContext = new InventoryDbContext();
        }
        public bool AddProduct(Product product)
        {
            try
            {
                if (product.IsValid())
                {
                    var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Name == product.Name);

                    if (existingProduct != null)
                    {
                        existingProduct.Quantity += product.Quantity;
                    }
                    else
                    {
                        _dbContext.Products.Add(product);
                    }

                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }
        public List<Product> FetchAllProducts()
        {
            try
            {
                return _dbContext.Products.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<Product>();
            }
        }
        public bool EditProduct(string productName, string newName, decimal newPrice, int newQuantity)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Name == productName);
            if (existingProduct != null)
            {
                existingProduct.Price = newPrice;
                existingProduct.Quantity = newQuantity;
                existingProduct.Price= newPrice;
                _dbContext.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool DeleteProduct(string productName)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Name == productName);
            if (existingProduct != null)
            {
                _dbContext.Products.Remove(existingProduct);
                _dbContext.SaveChanges();
                return true;
            }
            else return false; 
        }
        public Product SearchForProduct(string productToDeleteName)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Name == productToDeleteName); ;
        }
    }

}
