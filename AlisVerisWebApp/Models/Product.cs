using Microsoft.AspNetCore.Http.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlisVerisWebApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Product_Name { get; set; } = string.Empty;

        public string Product_Description { get; set; } = string.Empty;

        public string Product_Image { get; set; } = string.Empty;

        public decimal? Product_Price { get; set;}
        [ForeignKey("Category")]

        public int? Category_Id { get; set; }

        public virtual Category? Category { get; set; }
        [ForeignKey("SubCategories")]

        public int? SubCategory_Id { get; set; }

        public virtual SubCategory? SubCategory { get; set; }

        public string Product_Feature { get; set; } = string.Empty;

        public List<ProductColor>? ProductColors { get; set; }
        public List<ProductSize>? ProductSize { get; set; }

        public List<Comment>? Comments { get; set; }

        [NotMapped]
        public IFormFile? PictureImage { get; set; } 
    }
}
