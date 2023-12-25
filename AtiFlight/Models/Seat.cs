using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtiFlight.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatID { get; set; }
        public int? YolcuId { get; set; }
        public Yolcu? Yolcu { get; set; }
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
