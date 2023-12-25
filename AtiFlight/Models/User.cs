using System.ComponentModel.DataAnnotations;
using System.Numerics;
using AtiFlight.Models;
using Microsoft.AspNetCore.Identity;

namespace AtiFlight.Models
{
    public class User:IdentityUser<int>
    {   
        public string NameSurname { get; set; }
     
        
    }
}
