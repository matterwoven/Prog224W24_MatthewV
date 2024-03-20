using System;
using System.Text;

namespace Prog224W24_YourName
{
    public class Receipt
    {
        public Order Order { get; set; }
        public double TotalPrice => Order.CalculateTotalPrice();
        //Needed help here, fixed it but it was a pain in the butt^
        //Reciept builder, contains order details regarding products
        public override string ToString()
        {
            StringBuilder reciept = new StringBuilder();
            reciept.AppendLine("\n\nReceipt:");
            reciept.AppendLine("Order Details:");
            foreach (var product in Order.Products)
            {
                reciept.AppendLine($"{product.Name}: ${product.Price}");
            }
            reciept.AppendLine($"Total Price: ${TotalPrice}\n\nThank you for visiting Why is it still dark outside, Joe?\n\n");
            return reciept.ToString();
        }
    }
}
