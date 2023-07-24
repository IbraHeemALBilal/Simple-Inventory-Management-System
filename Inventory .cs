using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    internal class Inventory
    {
        private ArrayList products;
        public Inventory()
        { 
            products = new ArrayList();
        }  
        public void add(Product product)
        {
            int _existsInList = 0;
            foreach(Product p in products)
            {
                if((p.name)==(product.name))
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
        }//add
        public void display()
        {
            foreach (Product p in products)
            {
                Console.WriteLine("Name : " + p.name + " ||  " + "Price : " + p.price + " ||  " + "Quantity : " + p.quantity);
            }
        }// display
        public void edit(String product_Name)
        {
            int _existsInList = 0;
            foreach (Product p in products)
            {
                if ((p.name) == (product_Name))
                {
                    _existsInList = 1;
                    Console.WriteLine("Enter the new name : ");
                    String new_Name = Console.ReadLine();
                    Console.WriteLine("Enter the new price : ");
                    double new_Price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new quantity : ");
                    int new_quantity = int.Parse(Console.ReadLine());
                    p.name = new_Name;
                    p.price = new_Price;
                    p.quantity = new_quantity;
                    Console.WriteLine("Product is edited :) ");

                    break;
                }
            }
            if (_existsInList == 0)
            {
                Console.WriteLine("Item not exists !! ");
            }
        }//edit
        public void delete(String product_Name)
        {
            int _existsInList = 0;
            foreach (Product p in products)
            {
                if ((p.name) == (product_Name))
                {
                    _existsInList = 1;
                    products.Remove(p);

                    break;
                }
            }
            if (_existsInList == 0)
            {
                Console.WriteLine("Item not exists !! ");
            }
        }//delete
        public void search(String product_Name)
        {
            int _existsInList = 0;
            foreach (Product p in products)
            {
                if ((p.name) == (product_Name))
                {
                    _existsInList = 1;
                    Console.WriteLine("Name : " + p.name + " ||  " + "Price : " + p.price + " ||  " + "Quantity : " + p.quantity);

                    break;
                }
            }
            if (_existsInList == 0)
            {
                Console.WriteLine("Item not exists !! ");
            }
        }//search


    }
}
