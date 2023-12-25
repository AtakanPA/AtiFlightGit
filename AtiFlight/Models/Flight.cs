using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtiFlight.Models
{
    public class Flight
    {
        [Key]
        [Display(Name = "Uçuş Numarası:")]
        public int FlightID { get; set; }
        [Display(Name ="Başlangıç Tarihi")]
        public DateTime Start {  get; set; }
        public bool IsActive { get; set; } = true;
        [Display(Name = "Bitiş Tarihi")]
        public DateTime End { get; set; }
        [ForeignKey("AirPlaneID")]
        [Display(Name ="Uçak")]
        public int? AirPlaneID { get; set; }
        [ForeignKey("AirPlaneID")]
        public AirPlane? AirPlane { get; set; }
        public int FlyRouteID { get; set; }
        public FlyRoute? FlyRoute { get; set; }
        [Display(Name ="Fiyat")]
        public double Price { get; set; }


    }
}
