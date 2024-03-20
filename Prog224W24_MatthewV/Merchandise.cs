namespace Prog224W24_YourName
{
    public class Merchandise : Product
    {
        //Represents merchendise, not the same as food and drink
        public string Category { get; set; }

        public override string GetProductType()
        {
            return "Merchandise";
        }
    }
}
