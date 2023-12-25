using System.ComponentModel.DataAnnotations;

namespace AtiFlight.Models
{
    public class Yolcu
    {
        [Key]
        public int YolcuId { get; set; }
        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Telefon numarası 10 basamaklı olmalıdır.")]
        public string TelNo { get; set; }

        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage = "Ad ve soyad gereklidir.")]
        [RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$", ErrorMessage = "Geçersiz karakterler içeriyor.")]
        public string AdSoyad { get; set; }

        [Display(Name ="Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet gereklidir.")]
        public int cinsiyet { get; set; }

        public List<Ticket>? tickets { get; set; }

    }
}
