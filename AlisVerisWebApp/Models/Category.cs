using System.ComponentModel.DataAnnotations;

namespace AlisVerisWebApp.Models
{
    public class Category
    {

        [Key]
        public int Category_Id { get; set; }

        [Required]
        [StringLength(100)] // İsteğe bağlı, max uzunluk eklemek için
        public string Category_Name { get; set; } = string.Empty;

        public virtual ICollection<SubCategory>? SubCategories { get; set; } = new HashSet<SubCategory>();
        public virtual ICollection<Product>? Products { get; set; } = new HashSet<Product>();
    }
}
