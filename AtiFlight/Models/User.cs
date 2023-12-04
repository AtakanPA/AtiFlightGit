using System.ComponentModel.DataAnnotations;
using System.Numerics;
using AtiFlight.Models;

namespace AtiFlight.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name="Ad Soyad")]
        [Required(ErrorMessage = "Lütfen isminizi girin.")]
        [MinLength(2, ErrorMessage = "İsim en az 2 karakter olmalıdır.")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }
        [Display(Name="Şifre")]
        [Required(ErrorMessage = "Şifre gereklidir.")]
        [MinLength(8,ErrorMessage ="Şifre en az 8 karakterli olmalıdır")]

        public string Password { get; set; }
        [Required]
        [Display(Name ="Telefon Numarası")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[-]?)?(?!0+$)\\d{10,15}$",ErrorMessage ="Lütfen geçerli bir telefon numarası giriniz")]
        public string Phone { get; set; }
        public List<Seat>? Seat { get; set; }
        public List<Flight>? Flight { get; set; }
        
    }
}
