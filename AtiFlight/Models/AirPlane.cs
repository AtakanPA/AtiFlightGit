using AtiFlight.Context;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtiFlight.Models
{
    public class AirPlane
    {
        [Key]
        public int AirPlaneID { get; set; }
        public string AirPlaneName { get; set; }
        

        public List<Seat>? Seats {  get; set; }
        public int? FlightID {  get; set; }
        public Flight? Flight { get; set; }
      
       
     
    }
}
