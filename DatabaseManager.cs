using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class DatabaseManager
    {
        private readonly string connectionString = "Server=DESKTOP-2628EB6;Database=SimpleInventoryManagmentDB;Integrated Security=True;";
        public bool AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    if (ProductExists(connection, product.Name))
                    {
                        UpdateProductQuantity(connection, product.Name, product.Quantity);
                    }
                    else
                    {
                        InsertNewProduct(connection, product);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }
        public List<Product> FetchAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(CreateProductFromReader(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            return products;
        }
        public bool EditProduct(string productName, string newName, decimal newPrice, int newQuantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    if (ProductExists(connection, productName))
                    {
                        UpdateProduct(connection, productName, newName, newPrice, newQuantity);
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
        }
        public bool DeleteProduct(string productName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    if (ProductExists(connection, productName))
                    {
                        DeleteProductFromDatabase(connection, productName);
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
        }
        public Product SearchForProduct(string productToDeleteName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand searchCommand = new SqlCommand("SELECT * FROM Products WHERE Name = @Name", connection);
                    searchCommand.Parameters.AddWithValue("@Name", productToDeleteName);

                    using (SqlDataReader reader = searchCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return CreateProductFromReader(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return null;
                }
            }
        }
        private bool ProductExists(SqlConnection connection, string productName)
        {
            SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Products WHERE Name = @Name", connection);
            checkCommand.Parameters.AddWithValue("@Name", productName);
            int existingCount = (int)checkCommand.ExecuteScalar();
            return existingCount > 0;
        }
        private void InsertNewProduct(SqlConnection connection, Product product)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)", connection);
            insertCommand.Parameters.AddWithValue("@Name", product.Name);
            insertCommand.Parameters.AddWithValue("@Price", product.Price);
            insertCommand.Parameters.AddWithValue("@Quantity", product.Quantity);
            insertCommand.ExecuteNonQuery();
        }
        private void UpdateProductQuantity(SqlConnection connection, string productName, int quantityToAdd)
        {
            SqlCommand updateCommand = new SqlCommand("UPDATE Products SET Quantity = Quantity + @Quantity WHERE Name = @Name", connection);
            updateCommand.Parameters.AddWithValue("@Name", productName);
            updateCommand.Parameters.AddWithValue("@Quantity", quantityToAdd);
            updateCommand.ExecuteNonQuery();
        }
        private void UpdateProduct(SqlConnection connection, string productName, string newName, decimal newPrice, int newQuantity)
        {
            SqlCommand updateCommand = new SqlCommand("UPDATE Products SET Name = @newName, Price = @newPrice, Quantity = @newQuantity WHERE Name = @Name", connection);
            updateCommand.Parameters.AddWithValue("@Name", productName);
            updateCommand.Parameters.AddWithValue("@newName", newName);
            updateCommand.Parameters.AddWithValue("@newPrice", newPrice);
            updateCommand.Parameters.AddWithValue("@newQuantity", newQuantity);
            updateCommand.ExecuteNonQuery();
        }
        private void DeleteProductFromDatabase(SqlConnection connection, string productName)
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE FROM Products WHERE Name = @Name", connection);
            deleteCommand.Parameters.AddWithValue("@Name", productName);
            deleteCommand.ExecuteNonQuery();
        }
        private Product CreateProductFromReader(SqlDataReader reader)
        {
            string productName = reader["Name"].ToString();
            decimal productPrice = Convert.ToDecimal(reader["Price"]);
            int productQuantity = Convert.ToInt32(reader["Quantity"]);
            return new Product(productName, productPrice, productQuantity);
        }
    }
}
