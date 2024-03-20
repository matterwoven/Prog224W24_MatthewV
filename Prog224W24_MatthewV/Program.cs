using System;

namespace Prog224W24_YourName
{
    class Program
    {
        //Matthew Vargas
        //Goal:
        //
        //-Reciept
        //-Navigation
        //
        //
        static void Main(string[] args)
        {
            // Initialize inventory and load data from JSON file
            Inventory inventory = new Inventory();
            inventory.LoadFromJson("inventory.json");
            // Main menu loop
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to the Why is it still dark outside, Joe? App");
                Console.WriteLine("1. Display Products");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Ring Up Customer");
                Console.WriteLine("4. Save and exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayProducts(inventory);
                        Console.Write("\n");
                        break;
                    case "2":
                        AddProduct(inventory);
                        break;
                    case "3":
                        RingUpCustomer(inventory);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid option (No symbols like $)\n");
                        break;
                }
            }

            // Save system below, for info on logic go to inventory section
            inventory.SaveToJson("inventory.json");
        }

        static void DisplayProducts(Inventory inventory)
        {
            Console.WriteLine("\nProducts in stock:");
            if (inventory.Products.Count == 0)
            {
                Console.WriteLine("No items are in stock.\n");
                return;
            }

            int index = 1;
            foreach (var product in inventory)
            {
                Console.WriteLine($"{index}. {product}");
                index++;
            }
        }

        static void AddProduct(Inventory inventory)
        {
            Console.Write("\nEnter product name: ");
            string name = Console.ReadLine();
            double price = 0;
            bool isValidPrice = false;

            while (!isValidPrice)
            {
                Console.Write("\nEnter product price: ");

                if (double.TryParse(Console.ReadLine(), out price))
                {
                    isValidPrice = true;
                }
                else
                {
                    Console.WriteLine("Invalid price, enter a valid one please.");
                }
            }

            Console.WriteLine("\nSelect product type:");
            Console.WriteLine("1. Beverage");
            Console.WriteLine("2. Food");
            Console.WriteLine("3. Merchandise");
            Console.Write("Enter your choice: ");
            string Choice = Console.ReadLine();

            Product product;
            switch (Choice)
            {
                case "1":
                    Console.Write("\nEnter beverage size (small, medium, large): \n");
                    string size = Console.ReadLine();
                    product = new Beverage { Name = name, Price = price, Size = size };
                    break;
                case "2":
                    Console.Write("\nEnter expiration date (yyyy-mm-dd): \n");
                    DateTime expirationDate = DateTime.Parse(Console.ReadLine());
                    product = new Food { Name = name, Price = price, ExpirationDate = expirationDate };
                    break;
                case "3":
                    Console.Write("\nEnter category (clothes, cups, etc): \n");
                    string category = Console.ReadLine();
                    product = new Merchandise { Name = name, Price = price, Category = category };
                    break;
                default:
                    Console.WriteLine("\nInvalid product type.\n");
                    return;
            }

            inventory.AddProduct(product);
            Console.WriteLine("Product added successfully!\n\n");
        }

        static void RingUpCustomer(Inventory inventory)
        {
            Order order = new Order();
            bool addMoreProducts = true;

            while (addMoreProducts)
            {
                DisplayProducts(inventory);
                Console.Write("\nSelect a product to add to the order (enter product number): \n");
                int productIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                if (productIndex < 0 || productIndex >= inventory.Products.Count)
                {
                    Console.WriteLine("\nInvalid product number.\n");
                    continue;
                }

                Product selectedProduct = inventory.Products[productIndex];
                order.AddProduct(selectedProduct);
                Console.WriteLine("\nProduct added to the order.\n");

                Console.Write("\nDo you want to add more products to the order? (yes/no): \n");
                string addMoreChoice = Console.ReadLine().ToLower();
                addMoreProducts = (addMoreChoice == "yes");
            }

            Console.WriteLine($"Total price of the order: ${order.CalculateTotalPrice()}");
            Receipt receipt = new Receipt { Order = order };
            Console.WriteLine(receipt);
        }
    }
}
