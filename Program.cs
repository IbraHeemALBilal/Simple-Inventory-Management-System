using System.Collections;

namespace Simple_Inventory_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            int choise;
            while (true)
            {

                Console.WriteLine("Choose what you need :  ");
                Console.WriteLine("1 - Add a product . ");
                Console.WriteLine("6 - Exit . ");
                Console.WriteLine("- - - - - - - - - - - - - ");
                choise = int.Parse(Console.ReadLine());
                if (choise == 1 )
                {
                    Console.WriteLine("Enter the name of the product : ");
                    String product_Name = Console.ReadLine();
                    Console.WriteLine("Enter the price of the product : ");
                    double product_Price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the quantity of the product : ");
                    int product_quantity = int.Parse(Console.ReadLine());
                    inventory.add(new Product(product_Name, product_Price, product_quantity));

                }//choise 1 to add 

                if (choise == 6)
                {
                    break;
                } //choise 6 to exit 

            }//while loop
        }
    }
}