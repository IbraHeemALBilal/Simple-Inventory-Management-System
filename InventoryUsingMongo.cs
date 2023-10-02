using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace SimpleInventoryManagementSystem
{
    public class InventoryUsingMongo : IInventoryManagment
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Product> _products;

        public InventoryUsingMongo()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("SimpleInventoryDB");
            _products = _database.GetCollection<Product>("Products");
        }

        public bool AddProduct(Product product)
        {
            if (product.IsValid())
            {
                try
                {
                    var existingProduct = _products.Find(Builders<Product>.Filter.Eq(p => p.Name, product.Name))
                                                    .FirstOrDefault();

                    if (existingProduct != null)
                    {
                        existingProduct.Quantity += product.Quantity;
                        var filter = Builders<Product>.Filter.Eq(p => p.Name, product.Name);
                        var update = Builders<Product>.Update.Set(p => p.Quantity, existingProduct.Quantity);
                        _products.UpdateOne(filter, update);
                    }
                    else
                    {
                        _products.InsertOne(product);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public List<Product> FetchAllProducts()
        {
            try
            {
                var projection = Builders<Product>.Projection.Exclude("_id");
                var bsonProducts = _products.Find(_ => true)
                                            .Project(projection)
                                            .ToList();

                var products = new List<Product>();
                foreach (var bsonProduct in bsonProducts)
                {
                    var product = BsonSerializer.Deserialize<Product>(bsonProduct);
                    products.Add(product);
                }

                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<Product>();
            }
        }
        public bool EditProduct(string productName, string newName, decimal newPrice, int newQuantity)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);
            var update = Builders<Product>.Update
                .Set(p => p.Name, newName)
                .Set(p => p.Price, newPrice)
                .Set(p => p.Quantity, newQuantity);

            var result = _products.UpdateOne(filter, update);

            return result.ModifiedCount > 0;
        }
        public bool DeleteProduct(string productName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);

            var result = _products.DeleteOne(filter);

            return result.DeletedCount > 0;
        }
        public Product SearchForProduct(string productName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);

            return _products.Find(filter).FirstOrDefault();
        }
    }
}
