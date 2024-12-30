using System.ComponentModel.DataAnnotations;

namespace AlisVerisWebApp.Models
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }
        public string SizeName { get; set; }

        public List<ProductSize>? ProductSize { get; set; }
    }
}
