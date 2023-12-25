using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace AtiFlight.Models
{
    public class FlyRoute
    {
    

        [Key]
        public int FlyRouteID { get; set; }
        [Display(Name ="Nereden")]
        public int? StartID {  get; set; }
        [Display(Name = "Nereden")]
        public Iller ?Start {  get; set; }
        public bool isActive { get; set; } = true;
        [Display(Name = "Nereye")]
        public int? EndID { get; set; }
        [Display(Name = "Nereye")]
        public Iller ?End { get; set; }
        public List<Flight>? Flight { set; get; }
    }
}
