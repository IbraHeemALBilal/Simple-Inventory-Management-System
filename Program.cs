using System;
using System.Collections.Generic;

namespace Simple_Inventory_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            int choice;
            while (true)
            {
                Console.WriteLine("- - - - - - - - - - - - - ");
                Console.WriteLine("Choose what you need :  ");
                Console.WriteLine("1 - Add a product . ");
                Console.WriteLine("2 - View all products . ");
                Console.WriteLine("3 - Edit a product . ");
                Console.WriteLine("4 - Delete a product . ");
                Console.WriteLine("5 - Search for a product . ");
                Console.WriteLine("6 - Exit . ");
                Console.WriteLine("- - - - - - - - - - - - - ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please choose a number from 1-6.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the name of the product : ");
                        string product_Name = Console.ReadLine();
                        Console.WriteLine("Enter the price of the product : ");
                        double product_Price;
                        if (!double.TryParse(Console.ReadLine(), out product_Price))
                        {
                            Console.WriteLine("Invalid price input. Please enter a valid number.");
                            continue;
                        }
                        Console.WriteLine("Enter the quantity of the product : ");
                        int product_Quantity;
                        if (!int.TryParse(Console.ReadLine(), out product_Quantity))
                        {
                            Console.WriteLine("Invalid quantity input. Please enter a valid number.");
                            continue;
                        }
                        inventory.add(new Product(product_Name, product_Price, product_Quantity));
                        break;

                    case 2:
                        inventory.display();
                        break;

                    case 3:
                        Console.WriteLine("Enter the name of the product you want to edit: ");
                        string productToEdit = Console.ReadLine();
                        inventory.edit(productToEdit);
                        break;

                    case 4:
                        Console.WriteLine("Enter the name of the product you want to delete: ");
                        string productToDelete = Console.ReadLine();
                        inventory.delete(productToDelete);
                        break;

                    case 5:
                        Console.WriteLine("Enter the name of the product you want to search for: ");
                        string productToSearch = Console.ReadLine();
                        inventory.search(productToSearch);
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please choose a number from 1 - 6.");
                        break;
                }
            }
        }
    }
}