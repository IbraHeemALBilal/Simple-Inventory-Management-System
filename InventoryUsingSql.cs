using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SimpleInventoryManagementSystem
{
    public class InventoryUsingSql : IInventoryManagment
    {
        private readonly DatabaseManager _databaseManager;
        public InventoryUsingSql()
        {
            _databaseManager = new DatabaseManager();
        }
        public bool AddProduct(Product product)
        {
            if (product.IsValid())
            {
                return _databaseManager.AddProduct(product);
            }
            else
            {
                return false;
            }
        }
        public List<Product> FetchAllProducts()
        {
            return _databaseManager.FetchAllProducts();
        }
        public bool EditProduct(string productName, string newName, decimal newPrice, int newQuantity)
        {
            return _databaseManager.EditProduct(productName, newName, newPrice, newQuantity);
        }
        public bool DeleteProduct(string productName)
        {
            return _databaseManager.DeleteProduct(productName);
        }
        public Product SearchForProduct(string productToDeleteName)
        {
            return _databaseManager.SearchForProduct(productToDeleteName);
        }
    }
}
