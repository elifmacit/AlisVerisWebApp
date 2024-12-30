using System.ComponentModel.DataAnnotations;

namespace AlisVerisWebApp.Models
{
    public class ProductColor
    {
        [Key]
        public int ProductColorId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
