using System.ComponentModel.DataAnnotations;

namespace Day3_TaDucPhuc.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;
        //nagative navigation property ti Products
        public List<Product> Products { get; set; }
    }
}
