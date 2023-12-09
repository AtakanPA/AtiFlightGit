using Microsoft.AspNetCore.Identity;

namespace AtiFlight.Models
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole() : base()
        {
            // You can optionally add any custom initialization logic here if needed
        }

        // This constructor calls the base constructor with roleName
        public AppRole(string roleName) : base(roleName)
        {
            // You can optionally add any custom initialization logic here if needed
        }
    }
}
