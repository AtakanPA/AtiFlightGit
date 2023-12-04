using System.ComponentModel.DataAnnotations;

namespace AtiFlight.Models
{
    public class Seat
    {
        [Key]
        public int SeatID { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int SeatNumber { get; set; } 
        public int AirPlaneID { get; set; }
        public AirPlane? AirPlane { get; set; }
        public bool IsFull { get; set; }
        public Seat()
        {
          
            IsFull = false;
        }
    }
}
