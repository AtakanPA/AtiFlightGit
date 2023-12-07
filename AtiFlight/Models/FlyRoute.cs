using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace AtiFlight.Models
{
    public class FlyRoute
    {
    

        [Key]
        public int FlyRouteID { get; set; }
        
        public int? StartID {  get; set; }
        
        public Iller ?Start {  get; set; }
        public bool isActive { get; set; } = true;
   
        public int? EndID { get; set; }
      
        public Iller ?End { get; set; }
        public List<Flight>? Flight { set; get; }
    }
}
