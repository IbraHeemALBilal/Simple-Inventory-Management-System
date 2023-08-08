using System;

namespace SimpleInventoryManagementSystem
{
    internal class Program
    {
        private const int AddProductOption = 1;
        private const int ViewAllProductsOption = 2;
        private const int EditProductOption = 3;
        private const int DeleteProductOption = 4;
        private const int SearchProductOption = 5;
        private const int ExitOption = 6;

        static void Main(string[] args)
        {
            var inventory = new Inventory();
            int choice;
            while (true)
            {
                DisplayMenuOptions();

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid input. Please choose a number from 1-6.");
                    continue;
                }

                switch (choice)
                {
                    case AddProductOption:
                        AddProduct(inventory);
                        break;

                    case ViewAllProductsOption:
                        ViewAllProducts( inventory);
                        break;

                    case EditProductOption:
                        EditProduct(inventory);
                        break;

                    case DeleteProductOption:
                        DeleteProduct(inventory);
                        break;

                    case SearchProductOption:
                        SearchProduct(inventory);
                        break;

                    case ExitOption:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please choose a number from 1 - 6.");
                        break;
                }
            }
        }

        private static void DisplayMenuOptions()
        {
            Console.WriteLine("- - - - - - - - - - - - - ");
            Console.WriteLine("Choose what you need :  ");
            Console.WriteLine($"{AddProductOption} - Add a product.");
            Console.WriteLine($"{ViewAllProductsOption} - View all products.");
            Console.WriteLine($"{EditProductOption} - Edit a product.");
            Console.WriteLine($"{DeleteProductOption} - Delete a product.");
            Console.WriteLine($"{SearchProductOption} - Search for a product.");
            Console.WriteLine($"{ExitOption} - Exit.");
            Console.WriteLine("- - - - - - - - - - - - - ");
        }

        private static void AddProduct(Inventory inventory)
        {
            Console.WriteLine("Enter the name of the product: ");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter the price of the product: ");
            decimal productPrice;
            if (!decimal.TryParse(Console.ReadLine(), out productPrice) || productPrice < 0)
            {
                Console.WriteLine("Invalid price input. Please enter a valid non-negative number.");
                return;
            }

            Console.WriteLine("Enter the quantity of the product: ");
            int productQuantity;
            if (!int.TryParse(Console.ReadLine(), out productQuantity) || productQuantity < 0)
            {
                Console.WriteLine("Invalid quantity input. Please enter a valid non-negative number.");
                return;
            }

            if (inventory.Add(new Product(productName, productPrice, productQuantity)))
                Console.WriteLine("Product added :)");
            else
                Console.WriteLine("Product not valid :(");
        }
        private static void ViewAllProducts(Inventory inventory)
        {
            var productsToPrint = inventory.Display();
            if (productsToPrint.Count == 0)
            {
                Console.WriteLine("No products in the inventory.");
            }
            else
            {
                var productDetails = productsToPrint.Select(p => $"Name: {p.Name} || Price: {p.Price} || Quantity: {p.Quantity}");
                string output = string.Join(Environment.NewLine, productDetails);
                Console.WriteLine(output);
            }
        }
            private static void EditProduct(Inventory inventory)
            {
            Console.WriteLine("Enter the name of the product you want to edit: ");
            var productToEdit = Console.ReadLine();
            Console.WriteLine("Enter the new name: ");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter the new price: ");
            decimal newPrice;
            if (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice < 0)
            {
                Console.WriteLine("Invalid price input. Please enter a valid non-negative number.");
                return;
            }
            Console.WriteLine("Enter the new quantity: ");
            int newQuantity;
            if (!int.TryParse(Console.ReadLine(), out newQuantity) || newQuantity < 0)
            {
                Console.WriteLine("Invalid quantity input. Please enter a valid non-negative number.");
                return;
            }
            if (inventory.Edit(productToEdit, newName, newPrice, newQuantity))
                Console.WriteLine("Item edited :)");
            else
                Console.WriteLine("Item does not exist !!");
        }

        private static void DeleteProduct(Inventory inventory)
        {
            Console.WriteLine("Enter the name of the product you want to delete: ");
            var productToDelete = Console.ReadLine();
            if (inventory.Delete(productToDelete))
            {
                Console.WriteLine("Product is deleted :)");
            }
            else
            {
                Console.WriteLine("Item does not exist !!");
            }
        }

            private static void SearchProduct(Inventory inventory)
            {
                Console.WriteLine("Enter the name of the product that you want to search for: ");
                var productToSearch = Console.ReadLine();
                var searchedProduct = inventory.Search(productToSearch);
                if (searchedProduct != null)
                {
                    Console.WriteLine($"Name: {searchedProduct.Name} || Price: {searchedProduct.Price} || Quantity: {searchedProduct.Quantity}");
                }
                else
                {
                    Console.WriteLine("Item does not exist !! ");
                }
            }
        }
    }




