namespace Keedoozle_Fine_Food.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantiy { get; set; }
        public double Price { get; set; }
        public int ItemCategoryId { get; set; }
        public int Tax { get; set; }
    }
}
