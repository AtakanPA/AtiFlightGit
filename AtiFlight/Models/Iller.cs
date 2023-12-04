using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace AtiFlight.Models
{
    public class Iller
    {
        [Key]
        public int IlId { get; set; }

        public string Name { get; set; }

    }
}
