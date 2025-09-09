using Microsoft.AspNetCore.Identity;

namespace Demo.Models.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
