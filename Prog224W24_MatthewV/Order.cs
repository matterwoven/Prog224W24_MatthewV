using System;
using System.Collections.Generic;
using System.Linq;

namespace Prog224W24_YourName
{
    public class Order
    {
        public List<Product> Products { get; private set; }

        public Order()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public double CalculateTotalPrice()
        {
            return Products.Sum(p => p.Price);
        }
    }
}
