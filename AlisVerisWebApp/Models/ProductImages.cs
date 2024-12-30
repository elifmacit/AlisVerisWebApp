using System.ComponentModel.DataAnnotations;
namespace AlisVerisWebApp.Models
{
    public class ProductImages
    {
        [Key]
        public int ProductImageId { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        
    }
}
