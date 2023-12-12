using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtiFlight.Models
{
    public class Flight
    {
        [Key]
        public int FlightID { get; set; }
        public DateTime Start {  get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime End { get; set; }
        [ForeignKey("AirPlaneID")]
        public int AirPlaneID { get; set; }
        [ForeignKey("AirPlaneID")]
        public AirPlane? AirPlane { get; set; }
        public int FlyRouteID { get; set; }
        public FlyRoute? FlyRoute { get; set; }
        public double Price { get; set; }


    }
}
