using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlisVerisWebApp.Models
{
    public class SubCategory : ISubCategory
    {
        [Key]
        public int SubCategory_Id { get; set; }
        [Display(Name = "Alt Kategori Adı")]

        [Required]
        [StringLength(100)] // Maksimum uzunluk sınırı eklemek isteyebilirsiniz
        public string SubCategory_Name { get; set; } = string.Empty;
        [Display(Name = "Kategori Adı")]

        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public virtual Category? Category { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
