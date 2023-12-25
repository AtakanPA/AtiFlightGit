using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace AtiFlight.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }


        
        [Display(Name ="Uçuş Numarası:")]
        public int? FlightID { get; set; }
        [Display(Name = "Uçuş Numarası:")]
        public Flight? Flight { get; set; }
        [Display(Name ="Koltuk Numarası:")]
        public int? SeatID { get; set; }
        [Display(Name = "Koltuk Numarası:")]
        public Seat? Seat { get; set; }
        [Display(Name="PNR Numarası:")]
        public string? PNR { get; set; }
        [Display(Name ="Yolcu:")]
        public int? YolcuId { get; set; }
        [Display(Name = "Yolcu:")]
        public Yolcu? Yolcu { get; set; }










    }
}
