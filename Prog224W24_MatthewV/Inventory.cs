using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Prog224W24_YourName
{
    public class Inventory : IEnumerable<Product>
    {
        public List<Product> Products { get; private set; }
        //Goals:
        //-Add and remove product
        //-Save system for user
        //List for products to move around


        public Inventory()
        {
            Products = new List<Product>();
        }
        // Product management
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
        // Product management
        public void SaveToJson(string filePath)
        {
            string jsonString = JsonSerializer.Serialize(Products);
            File.WriteAllText(filePath, jsonString);
        }

        public void LoadFromJson(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                Products = JsonSerializer.Deserialize<List<Product>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nJSON file wasn't detected\n");
            }
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return ((IEnumerable<Product>)Products).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Product>)Products).GetEnumerator();
        }
    }
}
