namespace Keedoozle_Fine_Food.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Discount { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double GrandTotal { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
