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

    }
}
