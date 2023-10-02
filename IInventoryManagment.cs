using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public interface IInventoryManagment
    {
        public bool AddProduct(Product product);
        public List<Product> FetchAllProducts();
        public bool EditProduct(string productName, string newName, decimal newPrice, int newQuantity);
        public bool DeleteProduct(string productName);
        public Product SearchForProduct(string productToDeleteName);

    }
}
