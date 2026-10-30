namespace Day3_TaDucPhuc.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        //foreign key to Category
        public int CategoryId { get; set; }
        //Navigation property to Category
        public Category? Category { get; set; }
    }
}
