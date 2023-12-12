using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace AtiFlight.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

      
       

        public int FlightID { get; set; }
        public Flight? Flight { get; set; }
        public int? SeatID { get; set; }

        public Seat? Seat { get; set; }
        public string? PNR { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }










    }
}
