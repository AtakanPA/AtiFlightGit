using System.ComponentModel.DataAnnotations;

namespace AtiFlight.Models
{
    public class UserSignInViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre gereklidir.")]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakterli olmalıdır")]

        public string Password { get; set; }
    
    }
}
