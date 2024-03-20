using System;

namespace Prog224W24_YourName
{
    public class Food : Product
    {
        //food
        public DateTime ExpirationDate { get; set; }

        public override string GetProductType()
        {
            return "Food";
        }
    }
}
