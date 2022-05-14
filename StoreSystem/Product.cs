using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Name = "Not informed.";
            Price = 0;
        }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: ${Price}";
        }
    }
}
