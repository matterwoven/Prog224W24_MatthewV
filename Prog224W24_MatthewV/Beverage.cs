namespace Prog224W24_YourName
{
    public class Beverage : Product
    {
        //drinks
        public string Size { get; set; }

        public override string GetProductType()
        {
            return "Beverage";
        }
    }
}
