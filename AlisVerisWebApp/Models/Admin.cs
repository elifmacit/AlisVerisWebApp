using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlisVerisWebApp.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]

        public int AdminName { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
        public string AdminPassword { get; set; }
       
    }

}
