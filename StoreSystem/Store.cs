using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem
{
    public class Store
    {
        public List<Product> ProductList { get; set; }
        public List<Product> ShoppingList { get; set; }

        public Store()
        {
            ProductList = new List<Product>();
            ShoppingList = new List<Product>();
        }

        public double Bill()
        {
            double totalPrice = 0;

            foreach (var product in ShoppingList)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }

    }
}
