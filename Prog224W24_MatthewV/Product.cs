using System;

namespace Prog224W24_YourName
{
    public abstract class Product
    {
        //Origin of all products
        public string Name { get; set; }
        public double Price { get; set; }

        public abstract string GetProductType();

        public override string ToString()
        {
            return $"{Name}: ${Price}";
        }
    }
}
